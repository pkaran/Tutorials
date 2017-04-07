package LanguageCore.oopdemo;

//in Java, all class objects must be dynamically allocated i.e. using new
public class Employee {

    private String name;
    private byte employeeTypeId = 1;

    //*********************************************TOPIC : constructors and this keyword

    /*The compiler automatically provides a no-argument, default constructor for any class without constructors.
    This default constructor will call the no-argument constructor of the superclass.
    When you do not explicitly define a constructor for a class, then Java creates a default constructor for the class.
    The default constructor automatically initializes all instance variables to their default values, which are
    zero, null, and false, for numeric types, reference types, and boolean, respectively.
    */
    public Employee(){

        //this can be used inside any method to refer to the current object
        this("DEFAULT NAME");
    }

    Employee(String name){
        this.name = name;
        finalField = 32;
    }

    //*********************************************END OF TOPIC : constructors and this keyword


    //*********************************************TOPIC : static and final

    /*
    Some restrictions associated with static methods :
        1. They cannot refer to this or super
        2. They can only use static variables and call static method
     */

    //final field must be assigned a value either when declared or in constructor
    final int finalField;
    static final int finalStaticField;  // must be initialized in static block or while declaration

    static int statInt;
    //static block that gets executed exactly once, when the class is first loaded
    static {
        System.out.println("Static block initialized.");
        statInt = 99;
        finalStaticField = 234;
    }

    //a static method
    public static void printEmployeeID(){
        System.out.println("Employee ID is " + finalStaticField);
    }

    //*********************************************END OF TOPIC : static and final


    //*********************************************TOPIC : inner class

    //inner classes can have the same access modifiers as other members of class
    public static class StaticInnerClass{

        void print(){
            //can access static members of enclosing class
            System.out.println("finalStaticField from Employee class is " + finalStaticField);
            printEmployeeID();

            //cannot access non-static members
            //System.out.println("employeeTypeId from Employee class is " + employeeTypeId);

        }
    }

    public class InnerClass{

        void print(){
            //can access static as well as non static members of enclosing class
            System.out.println("finalStaticField from Employee class is " + finalStaticField);
            getObjectType();      //non-static method
            printEmployeeID();      //static method
        }
    }

    //*********************************************ENF OF TOPIC : inner class


    //*********************************************TOPIC : variable length arguments

    //the variable-length parameter must be the last parameter declared by the method
    //There is one more restriction to be aware of: there must be only one varargs parameter.
    public void varLengthArgs(int j, String a, String... s){    //s is simply String[] s

        //s.length will be 0 in case no string is passed
        System.out.println("There are " + s.length + " strings passed as String...s");
    }

    /*
    Var args and ambiguity:

    public void varArg(int ... i)
    public void varArg(bool ... b)

    //this is okay
    varArg(1)
    varArg(true, false)

    //this will give compile time error !
    varArg()

    Consider:
    public void varArg(int i)
    public void varArg(int ... i)

    //this will give compilation error !
    varArg(1)
     */

    //*********************************************END OF TOPIC : variable length arguments

    //method below for demo purpose
    public void getObjectType(){

        System.out.println("Object is of type Employee");
    }

    //variable for demo purpose
    public int hiddenVar = 5;
}
