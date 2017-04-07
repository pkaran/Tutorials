package LanguageCore.oopdemo.interfaces;

//Your class can implement more than one interface, so the implements keyword is followed by a comma-separated list of the
// interfaces implemented by the class. By convention, the implements clause follows the extends clause, if there is one.
//If a class does not implement all methods defined by an interface, then it must be declared abstract
public class Atorvastatin implements GenericDrug{

    //productDescription below hides productDescription in interface
    private String productDescription = "This generic drug helps keep cholesterol under control.";
    private int price = 100;

    @Override
    public int getProductPrice() {
        return price;
    }

    public void printInfo(){
        System.out.println("(From Atorvastatin.java) This product is " + productDescription);    //uses Atorvastatin class's productDescription var

        //*****************using super to access members of GenericDrug Interface
        GenericDrug.super.printInfo();
    }

    @Override
    public boolean isCostlier(GenericDrug otherDrug){
        return this.price > otherDrug.getProductPrice();
    }
}
