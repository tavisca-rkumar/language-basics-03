using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public static class Program
    {
public static int GetDish(int[] index)
{
    for(int t=0;t<index.Length;t++)
    {
        if(index[t]!=0)
        return index[t];
    }
   return 9;
}
public static Boolean stringOfLengthOne(string diet)
{
int length=diet.Length;
if(length==1)
return true;
else
return false;
}

public static Boolean check_single_dish_found(int[] index,ref int output)
{
int count=0;
for(int y=0;y<index.Length;y++)
{
if(index[y]!=0)
{
    output=y;
count++;
}
}
if(count==1)
return true;
else
return false;
}

public static Boolean Check_next_element_same(string diet,int index) 
{
if(diet.Length-1==index)
{
    return true;
}
if( diet[index]==diet[index+1]+32 || diet[index]==diet[index+1]-32)
{
return false;
}
else
return true;
}

        public static void getDiet(int[] nutrition,ref int[] index,int size_) // t index size
        {
              int max=Int32.MinValue;
              int min=Int32.MaxValue;
              int length=nutrition.Length;
              if(size_==1)
              {
                for(int i=0;i<length;i++)
              {
              if( index[i]!=0 && max<nutrition[index[i]-1])
              max=nutrition[index[i]-1];
              }
              min=max;
          
              }
              else
              {
                for(int i=0;i<length;i++)
              {
              if(index[i]!=0 && min>nutrition[index[i]-1])
              min=nutrition[index[i]-1];
              }
              max=min;
              }
              for(int i=0;i<index.Length;i++)
              {
                  if(index[i]==0)
                  {
                  continue;
                  }
                  else
                  {
                   if(nutrition[index[i]-1]==max)
                   {
                    continue;
                   }
                   else
                   {
                       index[i]=0;
                   }
                  }
                  
              }
           
        }

        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
             int[] result=new int[dietPlans.Length];  
             int index_counter=0; 
             int[] calorie=new int[protein.Length];
             for(int i=0;i<protein.Length;i++)
             {
                 calorie[i]=protein[i]*5+carbs[i]*5+fat[i]*9;   
             }
             
           for(int pl=0;pl<dietPlans.Length;pl++)
            {
             int inner_index=0; 
              if(dietPlans[pl]=="")
               {
               result[index_counter++]=0;
               }
                 else{
                Boolean go_ahead=true; 
                int local_index=0;
                int[] index_save=new int[protein.Length]; 
                for(int i=1;i<=protein.Length;i++)
                {
                    index_save[local_index]=i;
                    local_index++;
                }
while(go_ahead)
{
switch(dietPlans[pl][inner_index])
{
    case 'P':
    getDiet(protein,ref index_save,1);
    break;
    case 'p':
    getDiet(protein,ref index_save,0);
    break;
    case 'C':
    getDiet(carbs,ref index_save,1);
    break;
    case 'c':
    getDiet(carbs,ref index_save,0);
    break;
    case 'F':
    getDiet(fat,ref index_save,1);
    break;
    case 'f':
    getDiet(fat,ref index_save,0);
    break;
    case 'T':
    getDiet(calorie,ref index_save,1);
    break;
    case 't':
    getDiet(calorie,ref index_save,0);
    break;
}

int output=0; 
if(stringOfLengthOne(dietPlans[pl]) || check_single_dish_found(index_save,ref output) && Check_next_element_same(dietPlans[pl],inner_index) )
{
    if(stringOfLengthOne(dietPlans[pl])) 
    {
        check_single_dish_found(index_save,ref output);
    }
result[index_counter++]=output;
go_ahead=false;
}
else
{
 if(dietPlans[pl].Length-1==inner_index)
 {
     result[index_counter++]=GetDish(index_save)-1;
    
 go_ahead=false;
 } 
 else
    go_ahead=true;
}
inner_index++;
}
}
}
return result;
        }
    }
}
