using czas;

namespace TimeUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TimeConstructorsExceptions() 
        {
            //assert
            Assert.Throws<ArgumentException>(() => { Time t9 = new Time(25, 20, 20, 20); });
            Assert.Throws<ArgumentException>(() => { Time t1 = new Time(0, 20, 20, 1100); });
            Assert.Throws<ArgumentException>(() => { Time t2 = new Time(29, 20, 20, 20); });
            Assert.Throws<ArgumentException>(() => { Time t3 = new Time(25, 20, 200); });
            Assert.Throws<ArgumentException>(() => { Time t4 = new Time(25,61); });
        }

        [Test]
        public void TimePeriodConstructorsExceptions()
        {
            //assert
            Assert.Throws<ArgumentException>(() => { TimePeriod t1 = new TimePeriod(25, 20, 61, 900); });
            Assert.Throws<ArgumentException>(() => { TimePeriod t2 = new TimePeriod(25, 20, 59,1000); });
            Assert.Throws<ArgumentException>(() => { TimePeriod t3 = new TimePeriod(25, 20, 60, 900); });
            Assert.Throws<ArgumentException>(() => { TimePeriod t4 = new TimePeriod(25, 60, 0, 900); });
            Assert.Throws<ArgumentException>(() => { TimePeriod t5 = new TimePeriod(25, 72); });
            Assert.DoesNotThrow(() => { TimePeriod t6 = new TimePeriod(120); });
            Assert.DoesNotThrow(() => { TimePeriod t6 = new TimePeriod(200,59,59,999); });
        }
        

        [Test]
        public void TimeOperators()
        {
            //arange
            Time T1 = new Time(23,23,23,23);
            Time T2 = new Time(23,23,23,23);
            Time T3 = new Time(23,23,23);
            Time T4 = new Time(23,10,0);
            Time T5 = new Time(23, 10);
            Time T6 = new Time(23);
            Time T7 = new Time();
            Time T8 = new Time(0,0,0,0);


            //assert
            Assert.IsTrue(T1 == T2);
            Assert.IsTrue(T2 != T3);
            Assert.IsTrue(T7 == T8);
            Assert.IsTrue(T1 > T7);
            Assert.IsFalse(T2 <= T7);
            Assert.IsFalse(T7 > T8);
            Assert.IsFalse(T1 < T8);
            Assert.IsTrue(T2 > T7);
        }

        [Test]
        public void TimePeriodOperators()
        {
            //arange
            TimePeriod t1 = new TimePeriod(25, 0);
            TimePeriod t2 = new TimePeriod();
            TimePeriod t3 = new TimePeriod(0,0,0,0);
            TimePeriod t4 = new TimePeriod(120,0,59,200);
            TimePeriod t5 = new TimePeriod(200, 0, 59, 120);


            //assert
            Assert.IsTrue(t2 == t3);
            Assert.IsFalse(t4 == t5);
            Assert.IsFalse(t5 <= t1);
            Assert.IsTrue(t1 > t2);
            Assert.IsFalse(t2 != t3);
        }
        [Test]
        public void TimePeriodPlus() 
        {
            //arange
            TimePeriod t1 = new TimePeriod(0);
            TimePeriod t2 = new TimePeriod(120,0,0,0);
            TimePeriod t3 = new TimePeriod(120, 50, 10, 100);
            TimePeriod t4 = new TimePeriod(100,9,49,900);


            //assert 
            Assert.IsTrue(t1.Plus(t2) == new TimePeriod(120));
            Assert.IsTrue(t3.Plus(t4) == new TimePeriod(221,0,0,0));
            Assert.IsFalse(t1.Plus(t2) == new TimePeriod(50,0,0,0));
        }

        [Test] 
        public void TimePlus()
        {
            //arange
            Time T1 = new Time(20,20,20,20);
            TimePeriod T2 = new TimePeriod(23, 23, 23, 23);


            //assert
            Assert.IsTrue(T1.Plus(T2) == new Time(19,43,43,43));
            Assert.IsFalse(T1.Plus(T2) == new Time(10,10,10,0));
        }

        [Test]
        public void TimeMinus()
        {
            //arange
            Time t1 = new Time(20, 20, 20, 20);
            TimePeriod t2 = new TimePeriod(20,20,20, 20);


            //asset
            Assert.IsTrue(t1.Minus(t2) == new Time());
            Assert.IsFalse(t1.Minus(t2) == new Time(23,59,59,999));
            Assert.IsTrue(t1.Minus(t2) != new Time(23, 59, 59, 999));
            
        }
    }
}