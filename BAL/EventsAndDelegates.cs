using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours, Worktype worktype)
        {
            Hours = hours;
            Worktype = worktype;
        }
        public int Hours { get; set; }
        public Worktype Worktype { get; set; }
    }

    public class EventsAndDelegatesVoidWithInput
    {
        /***** 2.1. Define Delegate *****/
        public delegate void VoidWorkPerformedHandler(int hours, Worktype worktype);

        /***** 1.1. Define Event *****/
        //           delegate                 event name
        public event VoidWorkPerformedHandler WorkPerformedEvent; // Event definition
        public event EventHandler WorkCompletedEvent;// built in eventHandler delegate "I have no custom event data to pass. I only want to notify you that the work is completed"
        
        public void Run()
        {
            Console.WriteLine(@"Void WithInput calling delegates directly:");
            /***** 2.2. Instantiate Delegate *****/
            VoidWorkPerformedHandler del1 = new VoidWorkPerformedHandler(voidWorkPerformedMethod1);
            VoidWorkPerformedHandler del2 = new VoidWorkPerformedHandler(voidWorkPerformedMethod2);
            VoidWorkPerformedHandler multicastDelegate = del1 + del2;


            /***** 2.3. Call Delegates *****/
            // Result of calling only delegate 1 and 2 separately
            del1(40, Worktype.Golf);
            del2(50, Worktype.Golf);

            // Result of calling multicastDelegate
            multicastDelegate(60, Worktype.Cleaning);

            Console.WriteLine(@"Void WithInput attaching two single delegates:");
            WorkPerformedEvent += new VoidWorkPerformedHandler(del1);
            WorkPerformedEvent += new VoidWorkPerformedHandler(del2);
            WorkPerformedEvent(60, Worktype.Golf);

            Console.WriteLine(@"Void WithInput attaching and calling multicast:");
            WorkPerformedEvent = null; // resetting event
            WorkPerformedEvent += new VoidWorkPerformedHandler(multicastDelegate);
            WorkPerformedEvent(70, Worktype.Golf);

            Console.WriteLine(@"Void WithInput attaching methods directly to event:");
            WorkPerformedEvent = null; // resetting event
            WorkPerformedEvent += voidWorkPerformedMethod1;
            WorkPerformedEvent(80, Worktype.Programming);

            Console.WriteLine(@"Proper way calling event through method:");
            OnWorkPerformedEvent(80, Worktype.Programming);
        }

        // 3. Find or create existing Handler Methods void
        static void voidWorkPerformedMethod1(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed1 called " + hours);
        }

        static void voidWorkPerformedMethod2(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed2 called " + hours);
        }

        // The proper way to call events is to through methods to do a null check
        protected virtual void OnWorkPerformedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkPerformedEvent != null)
            {
                WorkPerformedEvent(hours, worktype);
            }

            // Or casting delegate to event and calling event
            var del = WorkPerformedEvent as VoidWorkPerformedHandler;
            if (del != null)
            {
                del(hours, worktype);
            }
        }

        protected virtual void OnWorkCompletedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkCompletedEvent != null)
            {
                WorkCompletedEvent(this, EventArgs.Empty);
            }

            // Or casting delegate to event and calling event
            var del = WorkCompletedEvent as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);;
            }
        }
    }

    public class EventsAndDelegatesVoidWithInputStandardConventionNET
    {
        // Using .NET Convention for delegates saves us instantiating delegates

        /***** 2.1. Define Delegate *****/
        //public delegate void VoidWorkPerformedHandler(object sender, WorkPerformedEventArgs e);

        /***** 1.1. Define Event *****/
        //           delegate                 event name
        //public event VoidWorkPerformedHandler WorkPerformedEvent; // Event definition
        public event EventHandler WorkCompletedEvent;// built in eventHandler delegate "I have no custom event data to pass. I only want to notify you that the work is completed"

        /***** It's possible to skip delegate entirely and use the standard c# delegate *****/
        public event EventHandler<WorkPerformedEventArgs> WorkPerformedEvent; // Event definition

        public void Run()
        {
            //Console.WriteLine(@"Void WithInput calling delegates directly:");
            /***** 2.2. Instantiate Delegate *****/
            //VoidWorkPerformedHandler del1 = new VoidWorkPerformedHandler(voidWorkPerformedMethod1);
            //VoidWorkPerformedHandler del2 = new VoidWorkPerformedHandler(voidWorkPerformedMethod2);
            //VoidWorkPerformedHandler multicastDelegate = del1 + del2;


            /***** 2.3. Call Delegates *****/
            // Result of calling only delegate 1 and 2 separately
            //del1(40, Worktype.Golf);
            //del2(50, Worktype.Golf);

            // Result of calling multicastDelegate
            //multicastDelegate(60, Worktype.Cleaning);

            //Console.WriteLine(@"Void WithInput attaching two single delegates:");
            //WorkPerformedEvent += new VoidWorkPerformedHandler(del1);
            //WorkPerformedEvent += new VoidWorkPerformedHandler(del2);
            //WorkPerformedEvent(60, Worktype.Golf);

            //Console.WriteLine(@"Void WithInput attaching and calling multicast:");
            //WorkPerformedEvent = null; // resetting event
            //WorkPerformedEvent += new VoidWorkPerformedHandler(multicastDelegate);
            //WorkPerformedEvent(70, Worktype.Golf);

            //Console.WriteLine(@"Void WithInput attaching methods directly to event:");
            //WorkPerformedEvent = null; // resetting event
            //WorkPerformedEvent += voidWorkPerformedMethod1;
            //WorkPerformedEvent(80, Worktype.Programming);

            Console.WriteLine(@"Proper call of event with C# eventhandler and custom EventArgs:");
            OnWorkPerformedEvent(80, Worktype.Programming);

            WorkPerformedEvent += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            WorkPerformedEvent += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            WorkPerformedEvent(this, new WorkPerformedEventArgs(90, Worktype.Programming));


        }

        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Worker_Workperformed with EventArgs called " + e.Hours);
        }

        // 3. Find or create existing Handler Methods void
        //static void voidWorkPerformedMethod1(int hours, Worktype workType)
        //{
        //    Console.WriteLine("Workperformed1 called " + hours);
        //}

        //static void voidWorkPerformedMethod2(int hours, Worktype workType)
        //{
        //    Console.WriteLine("Workperformed2 called " + hours);
        //}

        // The proper way to call events is to through methods to do a null check
        protected virtual void OnWorkPerformedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkPerformedEvent != null)
            {
                WorkPerformedEvent(this, new WorkPerformedEventArgs(hours, worktype));
            }

            // Or casting delegate to event and calling event
            var del = WorkPerformedEvent as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, worktype));
            }
        }

        protected virtual void OnWorkCompletedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkCompletedEvent != null)
            {
                WorkCompletedEvent(this, EventArgs.Empty);
            }

            // Or casting delegate to event and calling delegate
            var del = WorkCompletedEvent as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty); ;
            }
        }
    }

    public class EventsAndDelegatesVoidWithStandardConventionNETAnonymousMethods
    {
        //           delegate                 event name
        //public event VoidWorkPerformedHandler WorkPerformedEvent; // Event definition
        public event EventHandler WorkCompletedEvent;// built in eventHandler delegate "I have no custom event data to pass. I only want to notify you that the work is completed"

        /***** It's possible to skip delegate entirely and use the standard c# delegate *****/
        public event EventHandler<WorkPerformedEventArgs> WorkPerformedEvent; // Event definition

        public void Run()
        {
            Console.WriteLine(@"Proper call of event with C# eventhandler and custom EventArgs:");
            OnWorkPerformedEvent(80, Worktype.Programming);
            // Anonymous Method using delegate
            WorkPerformedEvent += delegate(object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Anonymous (prev. Workperformed1) with EventArgs called " + e.Hours);
            };
            // Anonymous Method using lambda
            WorkPerformedEvent += (sender, e) =>
            {
                Console.WriteLine("Lambda (prev. Workperformed2) with EventArgs called " + e.Hours);
            };
            WorkPerformedEvent(this, new WorkPerformedEventArgs(90, Worktype.Programming));


        }

        // No longer need due to anonymous methods
        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Anonymous (prev. Workperformed1) with EventArgs called " + e.Hours);
        //}
        

        // The proper way to call events is to through methods to do a null check
        protected virtual void OnWorkPerformedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkPerformedEvent != null)
            {
                WorkPerformedEvent(this, new WorkPerformedEventArgs(hours, worktype));
            }

            // Or casting delegate to event and calling event
            var del = WorkPerformedEvent as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, worktype));
            }
        }

        protected virtual void OnWorkCompletedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkCompletedEvent != null)
            {
                WorkCompletedEvent(this, EventArgs.Empty);
            }

            // Or casting delegate to event and calling delegate
            var del = WorkCompletedEvent as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty); ;
            }
        }
    }

    public class EventsAndDelegatesAction
    {
        public delegate void WorkCompletedHandler(int hours, Worktype worktype);
        public event WorkCompletedHandler WorkCompletedEvent;

        //           delegate                 event name
        //public event VoidWorkPerformedHandler WorkPerformedEvent; // Event definition
        public event Action<int, Worktype> WorkCompletedEventAction;// built in eventHandler delegate "I have no custom event data to pass. I only want to notify you that the work is completed"

        /***** It's possible to skip delegate entirely and use the standard c# delegate *****/
        public event Action<int, Worktype> WorkPerformedEvent; // Event definition

        public void Run()
        {
            Console.WriteLine(@"Proper call of event with Action and anonymous methods attached to it:");
            Action<int, Worktype> delAction1 = (h, w) =>
            {
                Console.WriteLine("Action Lambda (prev. Workperformed1) with EventArgs called " + h);
            };
            Action<int, Worktype> delAction2 = (h, w) =>
            {
                Console.WriteLine("Action Lambda (prev. Workperformed2) with EventArgs called " + h);
            };
            WorkCompletedEventAction += delAction1 + delAction2;
            WorkCompletedEventAction(50, Worktype.Cleaning);
            OnWorkCompletedEvent(60, Worktype.Golf);



            Console.WriteLine(@"Proper call of event with custom delegate and anonymous methods attached to it:");
            WorkCompletedHandler del1 = (hours, workType) =>
            {
                Console.WriteLine("Lambda (prev. Workperformed1) with EventArgs called " + hours);
            };
            WorkCompletedHandler del2 = (hours, workType) =>
            {
                Console.WriteLine("Lambda (prev. Workperformed2) with EventArgs called " + hours);
            };
            WorkCompletedEvent += del1 + del2;
            WorkCompletedEvent(100, Worktype.Programming);
            OnWorkCompletedEvent(110, Worktype.Golf);



            Console.WriteLine(@"Proper call of event with Action delegate and methodHandlers attached to it:");
            WorkCompletedEventAction = null;
            Action<int, Worktype> delMethodHandler1 = voidWorkPerformedMethod1;
            Action<int, Worktype> delMethodHandler2 = voidWorkPerformedMethod2;
            WorkCompletedEventAction += delMethodHandler1 + delMethodHandler2;
            WorkCompletedEventAction(150, Worktype.Programming);
            OnWorkCompletedEvent(160, Worktype.Golf);
        }

        static void voidWorkPerformedMethod1(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed1 called " + hours);
        }

        static void voidWorkPerformedMethod2(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed2 called " + hours);
        }


        // The proper way to call events is to through methods to do a null check
        protected virtual void OnWorkPerformedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkPerformedEvent != null)
            {
                WorkPerformedEvent(hours, worktype);
            }

            // Or casting delegate to event and calling event
            var del = WorkPerformedEvent as Action<int, Worktype>;
            if (del != null)
            {
                del(hours, worktype);
            }
        }

        protected virtual void OnWorkCompletedEvent(int hours, Worktype worktype)
        {
            // Either calling the event
            if (WorkCompletedEventAction != null)
            {
                WorkCompletedEventAction(hours, worktype);
            }

            // Or casting delegate to event and calling delegate
            var del = WorkCompletedEventAction as Action<int, Worktype>;
            if (del != null)
            {
                del(hours, worktype);
            }
        }
    }

    public class EventsAndDelegatesReturnValueWithInput
    {
        /***** 1.1. Define Delegate *****/
        public delegate int WorkPerformedHandler(int hours, Worktype worktype);

        public void Run()
        {
            Console.WriteLine(@"ReturnValue WithInput calling delegates directly:");
            /***** 1.2. Instantiate Delegate *****/
            WorkPerformedHandler del1 = new WorkPerformedHandler(voidWorkPerformedMethod1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(voidWorkPerformedMethod2);
            WorkPerformedHandler multicastDelegate = del1 + del2;


            /***** 1.3. Call Delegates *****/
            // Result of calling only delegate 1 and 2 separately
            var resultDel1 = del1(40, Worktype.Golf);
            Console.WriteLine("Result returned: " + resultDel1);

            var resultDel2 = del2(50, Worktype.Golf);
            Console.WriteLine("Result returned: " + resultDel2);

            // Result of calling multicastDelegate
            var resultMulticast = multicastDelegate(60, Worktype.Cleaning);
            Console.WriteLine("Result returned: " + resultMulticast);
        }

        // 3. Find or create existing Handler Methods void
        static int voidWorkPerformedMethod1(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed1 called " + hours);
            return hours * 2;
        }

        static int voidWorkPerformedMethod2(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed2 called " + hours);
            return hours * 10;
        }

        protected virtual void OnWorkCompletedEvent()
        {
        }
    }







    public class EventsAndDelegates
    {
        /***** 1. Define Delegate *****/
        public delegate void VoidWorkPerformHandler(int hours, Worktype workType);
        public delegate int ReturnValueWorkPerformHandler(int hours, Worktype worktype);

        // Later... Define Events
        //           delegate               event name
        public event VoidWorkPerformHandler WorkPerformedEvent; // Event definition

        // built in eventHandler delegate
        // Has no event data. "I only want to notify you that the work is completed"
        public event EventHandler WorkCompletedEvent;

        public void Run()
        {
            /**** Instantiate Delegates *****/

            // 2. Instantiate Delegate void
            VoidWorkPerformHandler voidDelegateWPH1 = new VoidWorkPerformHandler(voidWorkPerformedMethod1);
            VoidWorkPerformHandler voidDelegateWPH2 = new VoidWorkPerformHandler(voidWorkPerformedMethod2);
            VoidWorkPerformHandler voidMulticastDelegate = voidDelegateWPH1 + voidDelegateWPH2;

            // 2. Instantiate Delegate returnValue
            ReturnValueWorkPerformHandler returnValueDelegateWPH1 = new ReturnValueWorkPerformHandler(returnDoubleValueWorkPerformed);
            ReturnValueWorkPerformHandler returnValueDelegateWPH2 = new ReturnValueWorkPerformHandler(returnTripleValuekPerformed);
            ReturnValueWorkPerformHandler returnValueMulticastDelegate = returnValueDelegateWPH1 + returnValueDelegateWPH2;

            // Call returnValue multicast delegate
            // Note: only value of last invoked Handler Method gets returned
            int result = returnValueMulticastDelegate(3, Worktype.Cleaning);

            /**** Attach Delegates to Events *****/

            // Events are raised by calling the event like a method
            voidMulticastDelegate(3, Worktype.Cleaning);

            WorkPerformedEvent += voidMulticastDelegate;

            OnWorkPerformedEvent(50, Worktype.Programming);

            // We can also skip the event and invoke delegate directly
            // See above examples

        }
        
        // We need to attach delegate to event
        // Note: Event raising methods usually have to prefix "On..." or "Raise..."
        protected virtual void OnWorkPerformedEvent(int hours, Worktype worktype)
        {
            // You can call the event directly
            if (WorkPerformedEvent != null)
            {
                WorkPerformedEvent(hours, worktype);
            }

            // Or you can cast the delegate on the event
            var del = WorkPerformedEvent as VoidWorkPerformHandler;
            if (del != null)
            {
                del(hours, worktype);
            }
        }

        protected virtual void OnWorkCompletedEvent()
        {
            if (WorkCompletedEvent != null)
            {
                // "this" refers to this class
                WorkCompletedEvent(this, EventArgs.Empty);
            }
        }

        // 3. Handler Methods void
        static void voidWorkPerformedMethod1(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed1 called " + hours);
        }

        static void voidWorkPerformedMethod2(int hours, Worktype workType)
        {
            Console.WriteLine("Workperformed2 called " + hours);
        }

        // 3. Handler Methods returnValue
        static int returnDoubleValueWorkPerformed(int hours, Worktype workType)
        {
            int doubleHours = hours * 2;
            Console.WriteLine("Workperformed double called " + doubleHours);
            return doubleHours;
        }

        static int returnTripleValuekPerformed(int hours, Worktype workType)
        {
            int tripleHours = hours * 3;
            Console.WriteLine("Workperformed triple called " + tripleHours);
            return tripleHours;
        }
    }

    public class EventsAndDelagtesNoInputParams
    {
        // 2. Delegate
        public delegate void MyEventhandler();

        // 1. Event
        public event MyEventhandler myEvent;

        public void MainRun()
        {
            //MyEventhandler specificMulticastDelegate = new MyEventhandler(MethodPrintX) + new MyEventhandler(MethodPrintY);
            MyEventhandler specificDelegateX = new MyEventhandler(MethodPrintX);
            MyEventhandler specificDelegateY = new MyEventhandler(MethodPrintY);

            //myEvent += specificMulticastDelegate;
            myEvent += specificDelegateX + specificDelegateY;

            myEvent();
        }

        // 3. Methods
        public void MethodPrintX() { Console.WriteLine("Print void noParams X"); }
        public void MethodPrintY() { Console.WriteLine("Print void noParams Y"); }
    }

    public class EventsAndDelagtesWithInputParams
    {
        // 2. Delegate -> No need
        //public delegate void MyEventhandler(int integer, string simpleString);

        // 1. Event
        public event EventHandler<EventsAndDelagtesWithInputParamsEventArgs> myEvent;

        public event Action<EventsAndDelagtesWithInputParamsEventArgs> myActionEvent;

        public void OnSomethingIsDone()
        {
            // No need for delegates when working with eventArgs
            //MyEventhandler specificMulticastDelegate = new MyEventhandler(MethodPrintX) + new MyEventhandler(MethodPrintY);
            //MyEventhandler specificDelegateX = new MyEventhandler(MethodPrintX);
            //MyEventhandler specificDelegateY = new MyEventhandler(MethodPrintY);

            //myEvent += specificMulticastDelegate;
            //myEvent += specificDelegateX + specificDelegateY;
            //myEvent(this, new EventsAndDelagtesWithInputParamsEventArgs(0, "nothing to say") );

            // Since we don't need delegates, we can attach method kind of "directly"
            myEvent += new EventHandler<EventsAndDelagtesWithInputParamsEventArgs>(MethodPrintX);
            myEvent += new EventHandler<EventsAndDelagtesWithInputParamsEventArgs>(MethodPrintY);

            // Simple Anonymous Method
            myEvent += delegate(object sender, EventsAndDelagtesWithInputParamsEventArgs e)
            {
                Console.WriteLine("Simple anonymous method e:{0}, e:{1}", e.Integer, e.String);
            };

            // Simple Lambda
            myEvent += (s, e) => Console.WriteLine("Simple Lambda anonymous method e:{0}, e:{1}", e.Integer, e.String);

            // Multiline method Lambda
            myEvent += (s, e) =>
            {
                Console.WriteLine("Multiline Lambda anonymous method e:{0}, e:{1}", e.Integer, e.String);
            };

            myEvent(this, new EventsAndDelagtesWithInputParamsEventArgs(5, "myEvent"));
            //myEvent(5, "Hello World");

            ////////////////////////////////////
            
            myActionEvent += MethodPrintZ;
            myActionEvent(new EventsAndDelagtesWithInputParamsEventArgs(10, "myActionEvent"));

        }

        // 3. Methods
        public void MethodPrintX(object A, EventsAndDelagtesWithInputParamsEventArgs e) { Console.WriteLine("PrintX void withParams e:{0} - e:{1}", e.Integer, e.String); }
        public void MethodPrintY(object AA, EventsAndDelagtesWithInputParamsEventArgs ee) { Console.WriteLine("PrintY void withParams ee:{0} - ee:{1}", ee.Integer, ee.String); }

        public void MethodPrintZ(EventsAndDelagtesWithInputParamsEventArgs eee) { Console.WriteLine("PrintZ void withParams ee:{0} - ee:{1}", eee.Integer, eee.String); }

    }

    public class EventsAndDelagtesWithInputParamsEventArgs : EventArgs
    {
        public EventsAndDelagtesWithInputParamsEventArgs(int integer, string strings)
        {
            Integer = integer;
            String = strings;
        }
        public int Integer { get; set; }
        public string String { get; set; }
    }

    public enum Worktype
    {
        Programming,
        Golf,
        Cleaning
    }
}
