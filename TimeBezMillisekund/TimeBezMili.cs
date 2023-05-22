using System;
namespace TimeBezMillisekund

{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;
        

        public byte Hours => _hours;
        public byte Minutes => _minutes;
        public byte Seconds => _seconds;
        



        public Time(byte hours, byte minutes, byte seconds)
        {

            _hours = !(hours >= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = !(minutes >= 60) ? _minutes = minutes : throw new ArgumentException();
            _seconds = !(seconds >= 60) ? _seconds = seconds : throw new ArgumentException();
            
        }
        public Time(byte hours, byte minutes)
        {

            _hours = !(hours >= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = !(minutes >= 60) ? _minutes = minutes : throw new ArgumentException();
            _seconds = 0;
        }
       
        public Time(byte hours)
        {
            _hours = !(hours >= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = 0;
            _seconds = 0;
        }


        public Time(string czas)
        {

            if (string.IsNullOrEmpty(czas) || !czas.Contains(":"))
            {
                throw new ArgumentException("Czas jest nieprawidłowy");
            }
            byte zmienna;
            string[] timeParts;
            try
            {
                timeParts = czas.Split(':');
                if (timeParts.Length != 3) throw new ArgumentException();
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException();
            }
            zmienna = byte.TryParse(timeParts[0], out zmienna) ? (zmienna < 24) ? _hours = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[1], out zmienna) ? (zmienna < 60) ? _minutes = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[2], out zmienna) ? (zmienna < 60) ? _seconds = zmienna : throw new ArgumentException() : throw new ArgumentException();
            
        }


        public override string ToString() { return $"{_hours:D2}:{_minutes:D2}:{_seconds:D2}"; }

        public int CompareTo(Time other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Time other)
        {
            throw new NotImplementedException();
        }

        //przeciazanie operatora ==
        public static bool operator ==(Time a, Time b)
        {
            return ((a._hours).Equals(b._hours) && (a._minutes).Equals(b._minutes) && (a._seconds).Equals(b._seconds));
        }
        //przeciazanie operatora !=
        public static bool operator !=(Time a, Time b)
        {
            return !(a == b);
        }
        //przeciazanie operatora <
        public static bool operator <(Time a, Time b)
        {
            long A = Convert.ToInt64(a._hours) * 3600 + Convert.ToInt64(a._minutes) * 60 + Convert.ToInt64(a._seconds);
            long B = Convert.ToInt64(b._hours) * 3600 + Convert.ToInt64(b._minutes) * 60 + Convert.ToInt64(b._seconds);

            if (A < B)
            {
                return true;
            }
            else return false;
        }

        //przeciazanie operatora <=
        public static bool operator <=(Time a, Time b)
        {
            return (a < b || a == b) ? true : false;

        }

        //przeciazanie operatora >
        public static bool operator >(Time a, Time b)
        {
            return !(a <= b);
        }

        //przeciazanie operatora >=
        public static bool operator >=(Time a, Time b)
        {
            return (a > b || a == b) ? true : false;
        }

        public override bool Equals(object obj) => throw new NotImplementedException();

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        //działania arytmetyczne na czasie
        public Time Plus(TimePeriod b)
        {
            long A = Convert.ToInt64(_hours) * 3600 + Convert.ToInt64(_minutes) * 60 + Convert.ToInt64(_seconds);
            long B = Convert.ToInt64(b.Hours) * 3600 + Convert.ToInt64(b.Minutes) * 60 + Convert.ToInt64(b.Seconds);
            long zmienna = A + B;
            byte hours = (byte)((zmienna / 3600) % 24);
            byte minutes = (byte)((zmienna % 3600) / 60);
            byte seconds = (byte)(((zmienna % 3600) % 60));
            

            return new Time(hours, minutes, seconds);
        }
        //dopytac czy ten czas ma przechodzic w poprzedni dzien 
        public Time Minus(TimePeriod b)
        {
            long A = Convert.ToInt64(_hours) * 3600 + Convert.ToInt64(_minutes) * 60 + Convert.ToInt64(_seconds);
            long B = Convert.ToInt64(b.Hours) * 3600 + Convert.ToInt64(b.Minutes) * 60 + Convert.ToInt64(b.Seconds);

            long zmienna = A - B;
            byte hours = (byte)((zmienna / 3600) % 24);
            byte minutes = (byte)((zmienna % 3600) / 60);
            byte seconds = (byte)(((zmienna % 3600) % 60));
            

            return new Time(hours, minutes, seconds);
        }

        public static Time operator +(Time a, Time b)
        {
            long A = Convert.ToInt64(a._hours) * 3600 + Convert.ToInt64(a._minutes) * 60 + Convert.ToInt64(a._seconds);
            long B = Convert.ToInt64(b._hours) * 3600 + Convert.ToInt64(b._minutes) * 60 + Convert.ToInt64(b._seconds) * 1000;
            long zmienna = A + B;
            byte hours = (byte)((zmienna / 3600) % 24);
            byte minutes = (byte)((zmienna % 3600) / 60);
            byte seconds = (byte)(((zmienna % 3600) % 60));
            
            return new Time(hours, minutes, seconds);
        }

        public static Time operator -(Time a, Time b)
        {
            long A = Convert.ToInt64(a._hours) * 3600 + Convert.ToInt64(a._minutes) * 60 + Convert.ToInt64(a._seconds);
            long B = Convert.ToInt64(b._hours) * 3600 + Convert.ToInt64(b._minutes) * 60 + Convert.ToInt64(b._seconds);
            long zmienna = A - B;
            if (zmienna < 0)
            {
                zmienna = B - A;
                zmienna = 86400000 - zmienna;
            }
            byte hours = (byte)((zmienna / 3600) % 24);
            byte minutes = (byte)((zmienna % 3600) / 60);
            byte seconds = (byte)(((zmienna % 3600) % 60));
            
            return new Time(hours, minutes, seconds);
        }

        public Time PlusSeconds(byte seconds)
        {
            byte Hour = _hours;
            byte Min = _minutes;
            byte zmienaa = (byte)(_seconds + seconds);
            if (zmienaa >= 60)
            {

                zmienaa = 0;
                Min = (byte)(Min + 1);
            }
            if (Min >= 59)
            {
                Min = 0;
                Hour = (byte)(Hour + 1);
            }
            if (Hour >= 24)
            {
                Hour = 0;
            }
            return new Time(Hour, Min, zmienaa);
        }
       

        public static Time Now()
        {
            var now = DateTime.Now;
            return new Time((byte)now.Hour, (byte)now.Minute, (byte)now.Second);
        }


    }//koniec struktury Time

    public struct TimePeriod : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hours = 0;
        private readonly byte _minutes = 0;
        private readonly byte _seconds = 0;
       
        private readonly long _durationInSec;

        public byte Hours => _hours;
        public byte Minutes => _minutes;
        public byte Seconds => _seconds;
       
        public long DurationInSec => _durationInSec;



        public TimePeriod(byte hours, byte minutes, byte seconds)
        {

          



            if (seconds >= 60)
            {
                throw new ArgumentException("cant be more than 60");
            }
            _seconds = seconds;



            if (minutes >= 60)
            {
                throw new ArgumentException("cant be more than 60");
            }
            _minutes = minutes;




            _hours = hours;


            _durationInSec = (Convert.ToInt64(_hours) * 3600) + Convert.ToInt64(_minutes) * 60 + Convert.ToInt64(_seconds);

        }//koniec konstruktora 

        public TimePeriod(byte hours, byte minutes)
        {

           




            if (minutes >= 60)
            {
                throw new ArgumentException("cant be more than 60");
            }
            _minutes = minutes;




            _hours = hours;


            _durationInSec = Convert.ToInt64(_hours) * 3600 + Convert.ToInt64(_minutes) * 60 + Convert.ToInt64(_seconds);
        }//koniec konstruktora 

        public TimePeriod(byte hours)
        {
            _hours = hours;


            _durationInSec = Convert.ToInt64(_hours) * 3600;
        }//koniec konstruktora 

        

        public TimePeriod(string czas)
        {

            if (string.IsNullOrEmpty(czas) || !czas.Contains(":"))
            {
                throw new ArgumentException("Czas jest nieprawidłowy");
            }
            byte zmienna;
            
            string[] timeParts;
            try
            {
                timeParts = czas.Split(':');
                if (timeParts.Length != 3) throw new ArgumentException();
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException();
            }
            zmienna = byte.TryParse(timeParts[0], out zmienna) ? _hours = zmienna : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[1], out zmienna) ? (zmienna < 60) ? _minutes = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[2], out zmienna) ? (zmienna < 60) ? _seconds = zmienna : throw new ArgumentException() : throw new ArgumentException();
            
            _durationInSec = Convert.ToInt64(_hours) * 3600 + Convert.ToInt64(_minutes) * 60 + Convert.ToInt64(_seconds);

        }



        public TimePeriod(Time a, Time b)
        {
            long A = Convert.ToInt64(a.Hours) * 3600 + Convert.ToInt64(a.Minutes) * 60 + Convert.ToInt64(a.Seconds);
            long B = Convert.ToInt64(b.Hours) * 3600 + Convert.ToInt64(b.Minutes) * 60 + Convert.ToInt64(b.Seconds);
            long zmienna;

            if (a > b)
            {
                zmienna = A - B;

            }
            else if (b > a)
            {
                zmienna = B - A;
            }
            else
            {
                zmienna = B;
            }

            _hours = (byte)(zmienna / 3600);
            _minutes = (byte)((zmienna % 3600) / 60);
            _seconds = (byte)(((zmienna % 3600) % 60));
            
            _durationInSec = zmienna;

        }//koniec konstruktora */


        //ToString() override
        public override string ToString() => $"{_hours}:{_minutes:D2}:{_seconds:D2}";


        //przeciazanie operatora ==
        public static bool operator ==(TimePeriod a, TimePeriod b)
        {
            return ((a._hours).Equals(b._hours) && (a._minutes).Equals(b._minutes) && (a._seconds).Equals(b._seconds));
        }

        //przeciazanie operatora !=
        public static bool operator !=(TimePeriod a, TimePeriod b)
        {
            return !(a == b);
        }

        //przeciazanie operatora <
        public static bool operator <(TimePeriod a, TimePeriod b)
        {
            long A = Convert.ToInt64(a._hours) * 3600 + Convert.ToInt64(a._minutes) * 60 + Convert.ToInt64(a._seconds);
            long B = Convert.ToInt64(b._hours) * 3600 + Convert.ToInt64(b._minutes) * 60 + Convert.ToInt64(b._seconds);

            if (A < B)
            {
                return true;
            }
            else return false;
        }

        //przeciazanie operatora <=
        public static bool operator <=(TimePeriod a, TimePeriod b)
        {
            return (a < b || a == b) ? true : false;

        }

        //przeciazanie operatora >
        public static bool operator >(TimePeriod a, TimePeriod b)
        {
            return !(a <= b);
        }

        //przeciazanie operatora >=
        public static bool operator >=(TimePeriod a, TimePeriod b)
        {
            return (a > b || a == b) ? true : false;
        }

        public TimePeriod Plus(TimePeriod b)
        {
            long A = Convert.ToInt64(_hours) * 3600 + Convert.ToInt64(_minutes) * 60 + Convert.ToInt64(_seconds);
            long B = Convert.ToInt64(b.Hours) * 3600 + Convert.ToInt64(b.Minutes) * 60 + Convert.ToInt64(b.Seconds);
            long zmienna = A + B;
            byte hours = (byte)((zmienna / 3600));
            byte minutes = (byte)((zmienna % 3600) / 60);
            byte seconds = (byte)(((zmienna % 3600) % 60) / 10);

            return new TimePeriod(hours, minutes, seconds);
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Time other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Time other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}//Koniec przestrzeni nazw 
