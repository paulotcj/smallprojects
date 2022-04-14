using System;

namespace Clone
{
    class Program
    {
        static void Main(string[] args)
        {
            //------
            GenericClassForCopy objShallowCopy1 = new GenericClassForCopy(11111, "AAAAAAA", "BBBBBBB");
            GenericClassForCopy objShallowCopy2 = (GenericClassForCopy)objShallowCopy1.ShallowCopy(); 
            //------


            Console.WriteLine("Original Values: ");
            Console.WriteLine("Object 1:");
            Console.WriteLine(objShallowCopy1.valueProperty);
            Console.WriteLine(objShallowCopy1.referenceProperty.string_referenceProperty1);
            Console.WriteLine("Object 2:");
            Console.WriteLine(objShallowCopy2.valueProperty);
            Console.WriteLine(objShallowCopy2.referenceProperty.string_referenceProperty1);
        

            //MODIFICATIONS
            objShallowCopy2.valueProperty = 22222;
            objShallowCopy2.referenceProperty.string_referenceProperty1 = "WWWWW";
        
            Console.WriteLine("\nAfter Changing: ");
            
            Console.WriteLine("Object 1:");
            Console.WriteLine(objShallowCopy1.valueProperty);
            Console.WriteLine(objShallowCopy1.referenceProperty.string_referenceProperty1);
            Console.WriteLine("Object 2:");
            Console.WriteLine(objShallowCopy2.valueProperty);
            Console.WriteLine(objShallowCopy2.referenceProperty.string_referenceProperty1);


            //------
            GenericClassForCopy objDeepCopy1 = new GenericClassForCopy(3333, "CCCCCC", "DDDDDD");
            GenericClassForCopy objDeepCopy2 = objDeepCopy1.DeepCopy();
            //------

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Original Values: ");
            Console.WriteLine("Object 1:");
            Console.WriteLine(objDeepCopy1.valueProperty);
            Console.WriteLine(objDeepCopy1.referenceProperty.string_referenceProperty1);
            Console.WriteLine("Object 2:");
            Console.WriteLine(objDeepCopy2.valueProperty);
            Console.WriteLine(objDeepCopy2.referenceProperty.string_referenceProperty1);



            //MODIFICATIONS
            objDeepCopy2.valueProperty = 4444444;
            objDeepCopy2.referenceProperty.string_referenceProperty1 = "XXXXXX";


            Console.WriteLine("\nAfter Changing: ");
            Console.WriteLine("Object 1:");
            Console.WriteLine(objDeepCopy1.valueProperty);
            Console.WriteLine(objDeepCopy1.referenceProperty.string_referenceProperty1);
            Console.WriteLine("Object 2:");
            Console.WriteLine(objDeepCopy2.valueProperty);
            Console.WriteLine(objDeepCopy2.referenceProperty.string_referenceProperty1);

        }
    }


    //-----------------------

    class GenericClassForCopy 
    {
            
        public int valueProperty;
        public ClassForReferenceUse referenceProperty;
        
        #region constructor
        public GenericClassForCopy(int paramValue, string paramString1, string paramString2)
        {
            this.valueProperty = paramValue;
            referenceProperty = new ClassForReferenceUse(paramString1, paramString2);
        }
        #endregion
        
        
        //SHALLOW COPY
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        
        //DEEP COPY
        public GenericClassForCopy DeepCopy()
        {
            GenericClassForCopy objDeepCopy = new GenericClassForCopy
            (
                this.valueProperty,
                referenceProperty.string_referenceProperty1, 
                referenceProperty.string_referenceProperty2
            );
            return objDeepCopy;
        }
    }
      
      
    class ClassForReferenceUse 
    {
        
        public string string_referenceProperty1;
        public string string_referenceProperty2;
        public ClassForReferenceUse(string paramString1, string paramString2)
        {
            this.string_referenceProperty1 = paramString1;
            this.string_referenceProperty2 = paramString2;
        }
    }

    //----------------------------
}
