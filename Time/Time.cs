using System;
namespace czas

{
    public struct Time : IEquatable<Time>,IComparable<Time>
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;
        private readonly ushort _milliseconds;

        public byte Hours => _hours;
        public byte Minutes => _minutes; 
        public byte Seconds => _seconds;
        public ushort Milliseconds => _milliseconds;

        

        public Time(byte hours,byte minutes,byte seconds, ushort miliseconds)
        {
            
            _hours = !(hours >= 24) ? _hours  =hours : throw new ArgumentException();
            _minutes = !(minutes >= 60) ? _minutes = minutes: throw new ArgumentException();
            _seconds = !(seconds >= 60) ? _seconds = seconds: throw new ArgumentException();
            _milliseconds = !(miliseconds >= 1000) ? _milliseconds = miliseconds : throw new ArgumentException();
        }
        public Time(byte hours, byte minutes, byte seconds)
        {
            
            _hours = !(hours >= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = !(minutes >= 60) ? _minutes = minutes : throw new ArgumentException();
            _seconds = !(seconds >= 60) ? _seconds = seconds : throw new ArgumentException();
            _milliseconds = 0;
        }
        public Time(byte hours, byte minutes)
        {
            
            _hours = !(hours >= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = !(minutes >= 60) ? _minutes = minutes : throw new ArgumentException();
            _seconds = 0;
            _milliseconds = 0;
        }
        public Time(byte hours)
        {
            
            _hours = !(hours >= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = 0;
            _seconds = 0;
            _milliseconds = 0;
        }
        
        
        public Time(string czas)
        {
            
            if (string.IsNullOrEmpty(czas) || !czas.Contains(":"))
            {
                throw new ArgumentException("Czas jest nieprawidłowy");
            }
            byte zmienna;
            ushort zmienna2;
            string[] timeParts;
            try
            {
                timeParts = czas.Split(':');
                if(timeParts.Length !=4) throw new ArgumentException();
            }
            catch(IndexOutOfRangeException)
            {
                throw new ArgumentException();
            }
            zmienna = byte.TryParse(timeParts[0],out zmienna)?(zmienna<24)?_hours = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[1], out zmienna) ? (zmienna < 60) ? _minutes = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[2], out zmienna) ? (zmienna < 60) ? _seconds = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna2 = ushort.TryParse(timeParts[3], out zmienna2) ? (zmienna2 < 1000) ? _milliseconds = zmienna2 : throw new ArgumentException() : throw new ArgumentException();
        }
        
        
        public override string ToString() { return $"{_hours:D2}:{_minutes:D2}:{_seconds:D2}:{_milliseconds:D2}"; }

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
        return ((a._hours).Equals(b._hours) && (a._minutes).Equals(b._minutes) && (a._seconds).Equals(b._seconds) && (a._milliseconds).Equals(b._milliseconds));
        }
        //przeciazanie operatora !=
        public static bool operator !=(Time a,Time b)
        {
            return !(a == b);
        }
        //przeciazanie operatora <
        public static bool operator <(Time a,Time b)
        {
            long A = Convert.ToInt64(a._hours) * 3600000 + Convert.ToInt64(a._minutes) * 60000 + Convert.ToInt64(a._seconds) * 1000 + Convert.ToInt64(a._milliseconds);
            long B = Convert.ToInt64(b._hours) * 3600000 + Convert.ToInt64(b._minutes) * 60000 + Convert.ToInt64(b._seconds) * 1000 + Convert.ToInt64(b._milliseconds);

            if (A < B)
            {
            return true;
            }else return false;
        }
        
        //przeciazanie operatora <=
        public static bool operator <=(Time a, Time b)
        {
           return (a < b || a == b) ?true:false;
            
        }
        
        //przeciazanie operatora >
        public static bool operator >(Time a, Time b)
        {
            return !(a <= b);
        }
        
        //przeciazanie operatora >=
        public static bool operator >=(Time a, Time b)
        {
          return (a > b || a == b)?true:false;
        }

        public override bool Equals(object obj) => throw new NotImplementedException();

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        //działania arytmetyczne na czasie
        public Time Plus(TimePeriod b)
        {
            long A = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000 + Convert.ToInt64(_milliseconds);
            long B = Convert.ToInt64(b.Hours) * 3600000 + Convert.ToInt64(b.Minutes) * 60000 + Convert.ToInt64(b.Seconds) * 1000 + Convert.ToInt64(b.Milliseconds);
            long zmienna = A + B;
            byte hours = (byte)((zmienna / 3600000)%24);
            byte minutes = (byte)((zmienna % 3600000) / 60000);
            byte seconds = (byte)(((zmienna % 3600000) % 60000) / 1000);
            ushort milliseconds = (ushort)(((zmienna % 3600000) % 60000) % 1000);

            return new Time(hours,minutes,seconds,milliseconds);
        }
        //dopytac czy ten czas ma przechodzic w poprzedni dzien 
        public Time Minus(TimePeriod b)
        {
            long A = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000 + Convert.ToInt64(_milliseconds);
            long B = Convert.ToInt64(b.Hours) * 3600000 + Convert.ToInt64(b.Minutes) * 60000 + Convert.ToInt64(b.Seconds) * 1000 + Convert.ToInt64(b.Milliseconds);

            long zmienna = A - B;
            byte hours = (byte)((zmienna / 3600000) % 24);
            byte minutes = (byte)((zmienna % 3600000) / 60000);
            byte seconds = (byte)(((zmienna % 3600000) % 60000) / 1000);
            ushort milliseconds = (ushort)(((zmienna % 3600000) % 60000) % 1000);

            return new Time(hours, minutes, seconds, milliseconds);
        }

        public static Time operator +(Time a, Time b)
        {
            long A = Convert.ToInt64(a._hours) * 3600000 + Convert.ToInt64(a._minutes) * 60000 + Convert.ToInt64(a._seconds) * 1000 + Convert.ToInt64(a._milliseconds);
            long B = Convert.ToInt64(b._hours) * 3600000 + Convert.ToInt64(b._minutes) * 60000 + Convert.ToInt64(b._seconds) * 1000 + Convert.ToInt64(b._milliseconds);
            long zmienna = A + B;
            byte hours = (byte)((zmienna / 3600000) % 24);
            byte minutes = (byte)((zmienna % 3600000) / 60000);
            byte seconds = (byte)(((zmienna % 3600000) % 60000) / 1000);
            ushort milliseconds = (ushort)(((zmienna % 3600000) % 60000) % 1000);
            return new Time(hours, minutes, seconds, milliseconds);
        }

        public static Time operator -(Time a, Time b)
        {
            long A = Convert.ToInt64(a._hours) * 3600000 + Convert.ToInt64(a._minutes) * 60000 + Convert.ToInt64(a._seconds) * 1000 + Convert.ToInt64(a._milliseconds);
            long B = Convert.ToInt64(b._hours) * 3600000 + Convert.ToInt64(b._minutes) * 60000 + Convert.ToInt64(b._seconds) * 1000 + Convert.ToInt64(b._milliseconds);
            long zmienna = A - B;
            if(zmienna < 0)
            {
                zmienna = B - A;
                zmienna = 86400000 - zmienna;
            }
            byte hours = (byte)((zmienna / 3600000) % 24);
            byte minutes = (byte)((zmienna % 3600000) / 60000);
            byte seconds = (byte)(((zmienna % 3600000) % 60000) / 1000);
            ushort milliseconds = (ushort)(((zmienna % 3600000) % 60000) % 1000);
            return new Time(hours, minutes, seconds, milliseconds);
        }

        public Time PlusSeconds(byte seconds)
        {
            byte Hour = _hours;
            byte Min = _minutes;
            byte zmienaa = (byte)(_seconds + seconds);
            if(zmienaa >=60) {
                
                zmienaa = 0;
                Min = (byte)(Min + 1);
            }
            if(Min >= 59)
            {
                Min = 0;
                Hour = (byte)(Hour + 1);
            }
            if(Hour >= 24)
            {
                Hour = 0;
            }
            return new Time(Hour,Min,zmienaa);
        }
        public Time PlusMilli(ushort milliseconds) 
        {
            byte Hour = _hours;
            byte Min = _minutes;
            byte Sec = _seconds;
            ushort zmienaa = ((ushort)(_milliseconds + milliseconds));
            if (zmienaa > 999)
            {

                zmienaa = (ushort)(zmienaa % 1000);
                Sec = (byte)(Sec + 1);
            }
            if(Sec >= 60)
            {
                Sec = 0;
                Min += 1;
            }
            if (Min >= 60)
            {
                Min = 0;
                Hour = (byte)(Hour + 1);
            }
            if (Hour >= 24)
            {
                Hour = 0;
            }
            return new Time(Hour, Min, Sec ,zmienaa);
        }

        public static Time Now()
        {
            var now = DateTime.Now;
            return new Time((byte)now.Hour, (byte)now.Minute, (byte)now.Second, (ushort)now.Millisecond);
        }


    }//koniec struktury Time

    public struct TimePeriod : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hours = 0;
        private readonly byte _minutes = 0;
        private readonly byte _seconds = 0;
        private readonly ushort _milliseconds = 0;
        private readonly long _durationInMil;

        public byte Hours => _hours;
        public byte Minutes => _minutes;
        public byte Seconds => _seconds;
        public ushort Milliseconds => _milliseconds;
        public long DurationInMIl => _durationInMil;
        

        
          public TimePeriod(byte hours,byte minutes,byte seconds, ushort milliseconds)
        {
             
                 if(milliseconds >= 1000)
                 {
                    throw new ArgumentException("milliseconds more than 1000");
                 }
                 _milliseconds = milliseconds;
            

            
                if (seconds >= 60)
                {
                    throw new ArgumentException("cant be more than 60");
                }
                _seconds = seconds;
            
                 
             
                 if(minutes >= 60)
                 {
                    throw new ArgumentException("cant be more than 60");
                 }
                 _minutes = minutes;
             
              
             
             
                 _hours = hours;
             

            _durationInMil = (Convert.ToInt64(_hours) * 3600000) + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000 + Convert.ToInt64(_milliseconds);

        }//koniec konstruktora 
        
        public TimePeriod(byte hours,byte minutes,byte seconds)
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
             

            _durationInMil = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000;
        }//koniec konstruktora 
        
        public TimePeriod(byte hours,byte minutes)
        {
             
                 if(minutes >= 60)
                 {
                    throw new ArgumentException("cant be more than 60");
                 }
                 _minutes = minutes;
             
              
             
                 _hours = hours;
             

            _durationInMil = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000;
        }//koniec konstruktora 
        
        public TimePeriod(byte hours)
        {
             
             
             _hours = hours;
             _minutes = 0;
             _seconds = 0;
             _milliseconds = 0;
             _durationInMil = Convert.ToInt64(_hours) * 3600000;


        }//koniec konstruktora 

        public TimePeriod(string czas)
        {
            
            if (string.IsNullOrEmpty(czas) || !czas.Contains(":"))
            {
                throw new ArgumentException("Czas jest nieprawidłowy");
            }
            byte zmienna;
            ushort zmienna2;
            string[] timeParts;
            try
            {
                timeParts = czas.Split(':');
                if (timeParts.Length != 4) throw new ArgumentException();
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException();
            }
            zmienna = byte.TryParse(timeParts[0], out zmienna) ? _hours = zmienna : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[1], out zmienna) ? (zmienna < 60) ? _minutes = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna = byte.TryParse(timeParts[2], out zmienna) ? (zmienna < 60) ? _seconds = zmienna : throw new ArgumentException() : throw new ArgumentException();
            zmienna2 = ushort.TryParse(timeParts[3], out zmienna2) ? (zmienna2 < 1000) ? _milliseconds = zmienna2 : throw new ArgumentException() : throw new ArgumentException();
            _durationInMil = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000 + Convert.ToInt64(_milliseconds);

        }

        

        public TimePeriod(Time a, Time b)
        {
            long A = Convert.ToInt64(a.Hours) * 3600000 + Convert.ToInt64(a.Minutes) * 60000 + Convert.ToInt64(a.Seconds) * 1000 + Convert.ToInt64(a.Milliseconds);
            long B = Convert.ToInt64(b.Hours) * 3600000 + Convert.ToInt64(b.Minutes) * 60000 + Convert.ToInt64(b.Seconds) * 1000 + Convert.ToInt64(b.Milliseconds);
            long zmienna;

            if (a > b)
             {
                zmienna = A - B;
                
             }
            else if(b > a)
            {
                zmienna = B - A;
            }
            else
            {
                zmienna = B;
            }

            _hours = (byte)(zmienna / 3600000);
            _minutes = (byte)((zmienna % 3600000) / 60000);
            _seconds = (byte)(((zmienna % 3600000) % 60000) / 1000);
            _milliseconds = (ushort)(((zmienna % 3600000) % 60000) % 1000);
            _durationInMil = zmienna;

        }//koniec konstruktora */


        //ToString() override
        public override string ToString() => $"{_hours}:{_minutes:D2}:{_seconds:D2}:{_milliseconds:D2}";


        //przeciazanie operatora ==
        public static bool operator ==(TimePeriod a, TimePeriod b)
        {
            return ((a._hours).Equals(b._hours) && (a._minutes).Equals(b._minutes) && (a._seconds).Equals(b._seconds) && (a._milliseconds).Equals(b._milliseconds));
        }

        //przeciazanie operatora !=
        public static bool operator !=(TimePeriod a, TimePeriod b)
        {
            return !(a == b);
        }

        //przeciazanie operatora <
        public static bool operator <(TimePeriod a, TimePeriod b)
        {
            long A = Convert.ToInt64(a._hours) * 3600000 + Convert.ToInt64(a._minutes) * 60000 + Convert.ToInt64(a._seconds) * 1000 + Convert.ToInt64(a._milliseconds);
            long B = Convert.ToInt64(b._hours) * 3600000 + Convert.ToInt64(b._minutes) * 60000 + Convert.ToInt64(b._seconds) * 1000 + Convert.ToInt64(b._milliseconds);

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
            long A = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000 + Convert.ToInt64(_milliseconds);
            long B = Convert.ToInt64(b.Hours) * 3600000 + Convert.ToInt64(b.Minutes) * 60000 + Convert.ToInt64(b.Seconds) * 1000 + Convert.ToInt64(b.Milliseconds);
            long zmienna = A + B;
            byte hours = (byte)((zmienna / 3600000));
            byte minutes = (byte)((zmienna % 3600000) / 60000);
            byte seconds = (byte)(((zmienna % 3600000) % 60000) / 1000);
            ushort milliseconds = (ushort)(((zmienna % 3600000) % 60000) % 1000);

            return new TimePeriod(hours, minutes, seconds, milliseconds);
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
