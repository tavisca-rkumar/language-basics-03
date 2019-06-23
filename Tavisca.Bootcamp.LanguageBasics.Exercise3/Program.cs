using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
public static int kk(int[] l)
{
    int j=l.Length;
    for(int t=0;t<j;t++)
    {
        if(l[t]!=0)
        return l[t];
    }
   return 9;
}
public static Boolean stringl(string y)
{
int h=y.Length;
if(h==1)
return true;
else
return false;
}

public static Boolean onlyone(int[] ind,ref int gg)
{
int count=0;
int h=ind.Length;
//Console.WriteLine(h);
//Console.WriteLine(ind[0]);
for(int y=0;y<h;y++)
{
if(ind[y]!=0)
{
    gg=y;
count++;
}
}
if(count==1)
return true;
else
return false;
}

public static Boolean nextelement(string diet,int j) 
{
if(diet.Length-1==j)
{
    return true;
}
if( diet[j]==diet[j+1]+32 || diet[j]==diet[j+1]-32)
{
return false;
}
else
return true;
}
        public static void gett(int[] t,ref int[] ind,int y)
        {
              int max=Int32.MinValue;
              int min=Int32.MaxValue;
              //Console.WriteLine(min+" "+max);
              int k=t.Length;
              if(y==1)//max
              {
                for(int i=0;i<k;i++)
              {
              if( ind[i]!=0 && max<t[ind[i]-1])
              max=t[ind[i]-1];
              }
              min=max;
            //  Console.WriteLine(max+"maxy");
              }
              else
              {
                for(int i=0;i<k;i++)
              {
              if(ind[i]!=0 && min>t[ind[i]-1])
              min=t[ind[i]-1];
              }
              max=min;// for getting easy ..agge k liye 
              }
              int[] bb=new int[ind.Length];
              for(int i=0;i<ind.Length;i++)
              {
                  if(ind[i]==0)
                  {
                  continue;
                  }
                  else
                  {
                   if(t[ind[i]-1]==max)
                   {
                    continue;
                   }
                   else
                   {
                       ind[i]=0;
                   }
                  }
                  
              }
           // Console.WriteLine(max+"maxy");
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

        public static int[] SelectMeals(int[] p, int[] c, int[] f, string[] diet)
        {
            
                 int[] cal=new int[p.Length];
             for(int i=0;i<p.Length;i++)
             {
                 cal[i]=p[i]*5+c[i]*5+f[i]*9;
                
             }
             int[] yy=new int[diet.Length];
int vv=0;
for(int pl=0;pl<diet.Length;pl++)
{
    int d=0;
    if(diet[pl]=="")
    {
    yy[vv++]=0;
    }
    else{
    
     Boolean flag=true;
                int cs=0;
                int[] ind=new int[p.Length];
                for(int i=1;i<=p.Length;i++)
                {
                    ind[cs]=i;
                    
                   // Console.WriteLine(ind[cs]);
                    cs++;
                }
while(flag)
{
switch(diet[pl][d]) //2
{
    case 'P':
    gett(p,ref ind,1);
    break;
    case 'p':
    gett(p,ref ind,0);
    break;
    case 'C':
    gett(c,ref ind,1);
    break;
    case 'c':
    gett(c,ref ind,0);
    break;
    case 'F':
    gett(f,ref ind,1);
    break;
    case 'f':
    gett(f,ref ind,0);
    break;
    case 'T':
    gett(cal,ref ind,1);
    break;
    case 't':
    gett(cal,ref ind,0);
    break;
}
flag=false;

//Console.WriteLine("rajat"+ind[0]+""+ind[1]+""+ind[2]+""+ind[3]);

int gg=0;
if(stringl(diet[pl]) || onlyone(ind,ref gg) && nextelement(diet[pl],d) )
{
    if(stringl(diet[pl])) // this is for getiing gg if or wali first condition passed
    {
        onlyone(ind,ref gg);
    }
         yy[vv++]=gg;
flag=false;
}
else
{
 if(diet[pl].Length-1==d)
 {
     yy[vv++]=kk(ind)-1;
     //Console.WriteLine(+"final");
 flag=false;
 } 
 else
    flag=true;
}
d++;
//Console.WriteLine("hellogggggggg");

}
}
}
return yy;
        }
    }
}
