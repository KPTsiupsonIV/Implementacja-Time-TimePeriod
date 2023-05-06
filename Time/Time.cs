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
            //dopisac sprawdzanie parsowania
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
        
        //działania arytmetyczne na czasie
        
        


    }//koniec struktury Time

    public struct TimePeriod
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;
        private readonly ushort _milliseconds;
        private readonly long _durationInMil

        public byte Hours => _hours;
        public byte Minutes => _minutes;
        public byte Seconds => _seconds;
        public ushort Milliseconds => _milliseconds;
        public long DurationInMIl => _durationInMil;
        
        _durationInMil = Convert.ToInt64(_hours) * 3600000 + Convert.ToInt64(_minutes) * 60000 + Convert.ToInt64(_seconds) * 1000 + Convert.ToInt64(_milliseconds);
        
          public TimePeriod(byte hours,byte minutes,byte seconds, ushort miliseconds)
        {
             if(milliseconds != null)
             {
                 if(milliseconds >= 1000)
                 {
                     throw new ArgumentException("milliseconds more than 1000")
                 }
                 _milliseconds = milliseconds;
             }else throw new ArgumentException("cant be null");
              
             if(seconds != null)
             {
                 if(seconds >=60)
                 {
                     throw new ArgumentException("cant be more than 60");
                 }
                 _seconds = seconds;
             }else throw new ArgumentException("cant be null")
                 
             if(minutes != null)
             {
                 if(minutes >= 60)
                 {
                    throw new ArgumentException("cant be more than 60");
                 }
                 _minutes = minutes;
             }else throw new ArgumentException("cannot be null");
              
             if(hours != null)
             {
                 _hours = hours;
             }throw new ArgumentException("cannot be null"); 
              
        }//koniec konstruktora 
        
        public TimePeriod(byte hours,byte minutes,byte seconds)
        {
             if(seconds != null)
             {
                 if(seconds >=60)
                 {
                     throw new ArgumentException("cant be more than 60");
                 }
                 _seconds = seconds;
             }else throw new ArgumentException("cant be null")
                 
             if(minutes != null)
             {
                 if(minutes >= 60)
                 {
                    throw new ArgumentException("cant be more than 60");
                 }
                 _minutes = minutes;
             }else throw new ArgumentException("cannot be null");
              
             if(hours != null)
             {
                 _hours = hours;
             }throw new ArgumentException("cannot be null"); 
              
        }//koniec konstruktora 
        
        public TimePeriod(byte hours,byte minutes)
        {
             if(minutes != null)
             {
                 if(minutes >= 60)
                 {
                    throw new ArgumentException("cant be more than 60");
                 }
                 _minutes = minutes;
             }else throw new ArgumentException("cannot be null");
              
             if(hours != null)
             {
                 _hours = hours;
             }throw new ArgumentException("cannot be null"); 
              
        }//koniec konstruktora 
        
        public TimePeriod(byte hours)
        {
             if(hours != null)
             {
                 _hours = hours;
             }throw new ArgumentException("cannot be null"); 
              
        }//koniec konstruktora 
        
        public TimePeriod(Time a, Time b)
        {
             if(a > b)
             {
                 
             }
            else if(b > a)
            {
                
            }
            else
            {
                
            }
              
        }//koniec konstruktora 
        
    }
}//Koniec przestrzeni nazw 
