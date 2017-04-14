using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    // Onenote : Exception Handling
    class ExceptionHandling
    {
        public static void exceptionHandlingMain()
        {
            ExceptionHandling demo = new ExceptionHandling();

            //demo.throwException(true);
            //demo.throwAndCatch();
            //demo.multipleExceptions();
            //demo.exceptionWithinACatchBlock();
            //demo.finallyDemo();
            //demo.whenDemo();
        }

        void throwException(bool throwEx)
        {
            if (throwEx)
            {
                // Use the "throw" keyword to raise an exception.
                // *** IMP : If no exception handler for a given exception is present, the program stops executing with an error message.

                Exception e = new Exception(string.Format("This is a generic exception thrown from method {0}", "throwException()"));
                e.HelpLink = "www.google.com";

                // Stuff in custom data regarding the error.
                e.Data.Add("TimeStamp", string.Format("The exception was thrown at {0}", DateTime.Now));
                e.Data.Add("Cause", "You are stupid");

                throw e;
            }
        }

        void throwAndCatch()
        {

            /* a try block is a section of statements that may throw an exception during execution. If an
            exception is detected, the flow of program execution is sent to the appropriate catch block. On the other
            hand, if the code within a try block does not trigger an exception, the catch block is skipped entirely, and all
            is right with the world. */

            try
            {
                throwException(true);
            }
            catch(Exception e)
            {
                Console.WriteLine("\n*** Error! ***\n");

                //Message property
                Console.WriteLine("** Message Property **");
                Console.WriteLine("Message: {0}", e.Message);

                //TargetSite property
                Console.WriteLine("\n** TargetSite Property **\n");

                //Note : TargetSite actually returns a MethodBase object.
                Console.WriteLine("Member name: {0}", e.TargetSite);
                Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType); //fully qualified name of class throwing error
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType); // identify the type of member (such as a property versus a method)
                                                                                //where this exception originated

                //Source Property
                Console.WriteLine("\n** Source Property **\n");
                Console.WriteLine("Source: {0}", e.Source);

                /* stack trace property
                 
                The System.Exception.StackTrace property allows you to identify the series of calls that resulted in the
                exception. Be aware that you never set the value of StackTrace, as it is established automatically at the time
                the exception is created. 

                The string returned from StackTrace documents the sequence of calls that resulted in the throwing
                of this exception. Notice how the bottommost line number of this string identifies the first call in the
                sequence, while the topmost line number identifies the exact location of the offending member. Clearly, this
                information can be quite helpful during the debugging or logging of a given application, as you are able to
                “follow the flow” of the error’s origin. */

                Console.WriteLine("\n** Stack trace Property **\n");
                Console.WriteLine(e.StackTrace);

                // Helplink Property (also take a look at throwException(bool throwEx) to see how a link can be set up)

                Console.WriteLine("\n** Helplink Property **\n");
                Console.WriteLine("Help Link: {0}", e.HelpLink);  //HelpLink property can be set to point the user to a specific URL or standard Windows
                                                                  //help file that contains more detailed information.

                /*Data property (also take a look at throwException(bool throwEx) to see how property is set up)

                The Data property of System.Exception allows you to fill an exception object with relevant auxiliary
                information (such as a timestamp). The Data property returns an object implementing an interface named
                IDictionary, defined in the System.Collections namespace. 
                
                 The Data property is useful in that it allows you to pack in custom information regarding the error at
                hand, without requiring the building of a new class type to extend the Exception base class. As helpful as
                the Data property may be, however, it is still common for .NET developers to build strongly typed exception
                classes, which handle custom data using strongly typed properties.*/

                Console.WriteLine("\n** Data Property **\n");
                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("-> {0}: {1}", de.Key, de.Value);

                Console.WriteLine("\n*** Error! ***\n");
            }
            
        }

        void multipleExceptions()
        {
            /*
            In its simplest form, a try block has a single catch block. In reality, though, you often run into situations
            where the statements within a try block could trigger numerous possible exceptions.

            When you are authoring multiple catch blocks, you must be aware that when an exception is thrown,
            it will be processed by the first appropriate catch. */

            try
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException");
                throw new ArithmeticException("ArithmeticException");      
            }
            catch (ArithmeticException e)       // specialized exceptions must be mentioned in catch statement ABOVE general Exception class 
            {                                   // catch statement so that it will get caught by the top most matching catch statement
                Console.WriteLine("catch statement #1, caught : " + e.Message);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("catch statement #2, caught : " + e.Message);

                /*
                Throw the exception caught by the current catch statement.  You’re not creating a new exception object; you’re just
                rethrowing the original exception object (with all its original information). Doing so preserves the context of
                the original target. Do this when another exception handler can handle the current exception in a better manner
                 */

                throw;      // the exception thrown here will not be caught by the catch statement below. It needs to be 
                            // in its own try and catch block !
            }
            catch (Exception e)         // exceptions derived from a general exception class (like ArithmeticException or ArgumentOutOfRangeException)
            {                          //  MUST be placed above all general exceptions (such as System.Exception)

                // process all exceptions that are derived from System.Exception
                Console.WriteLine("catch statement #3, caught : " + e.Message);
            }
        }

        void exceptionWithinACatchBlock()
        {
            /*
             When you encounter an exception while processing another exception, best practice states that you
            should record the new exception object as an “inner exception” within a new object of the same type as the
            initial exception. (That was a mouthful!) The reason you need to allocate a new object of the exception being
            handled is that the only way to document an inner exception is via a constructor parameter. */

            try
            {
                throw new ArithmeticException();
            }
            catch(ArithmeticException e)
            {
                // some statements in catch block which itself cause an exception
                throw new ArithmeticException("Exception with an inner exception", new NullReferenceException());
            }

        }

        void finallyDemo()
        {
            /*A try/catch scope may also define an optional finally block. The purpose of a finally block is to ensure
            that a set of code statements will always execute, exception (of any type) or not. 
            
            In a more real-world scenario, when you need to
            dispose of objects, close a file, or detach from a database (or whatever), a finally block ensures a location
            for proper cleanup.
             */
            
            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception e)
            {
                Console.WriteLine("from catch : " + e.Message);
            }
            finally
            {
                Console.WriteLine("From finally : Do something like close file");
            }
        }

        void whenDemo()
        {
            /*The current release of C# introduces a new (and completely optional) clause that can be placed on a catch
            scope, via the when keyword. When you add this clause, you have the ability to ensure that the statements
            within a catch block are executed only if some condition in your code holds true.*/

            try
            {
                throw new Exception();
            }
            catch(Exception e) when (false)     // expression in () after when must evaluate to true for the catch statement to execute
            {                                   // exception is not caught if expression in () result to false
                Console.WriteLine("From catch of whenDemo()");
            }
        }
    }
}