package LanguageCore.oopdemo.abstractClass;

//An abstract class is a class that is declared abstract—it may or may not include abstract methods.
//Abstract classes cannot be instantiated, but they can be subclassed.
//abstract classes can have methods and fields just like any other normal class
public abstract class Shape {

    public Shape(){
        this("");
    }

    public Shape(String shapeDescription){
        this.shapeDescription = shapeDescription;
    }

    protected String shapeDescription;

    //An abstract method is a method that is declared without an implementation
    public abstract double area();

    /*
    An abstract class may have static fields and static methods. You can use these static members with a class reference
    (for example, AbstractClass.staticMethod()) as you would with any other class.
     */
    public void printShapeDescription(){
        System.out.println(shapeDescription);
    }

    //final methods cannot be overridden
    public final void thisClassCannotBeOverridden(){
        System.out.println("one way of using final is to prevent menthod overriding");
    }
}
