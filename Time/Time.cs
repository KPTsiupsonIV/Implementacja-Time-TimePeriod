namespace Time
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
                return throw new ArgumentException();
            }
            (byte.TryParse(timeParts[0],out zmienna)?(zmienna<24)?_hours = zmienna : throw new ArgumentException() : throw new ArgumentException();
            (byte.TryParse(timeParts[1],out zmienna)?(zmienna<60)?_minutes = zmienna : throw new ArgumentException() : throw new ArgumentException();
            (byte.TryParse(timeParts[2],out zmienna)?(zmienna<60)?_seconds = zmienna : throw new ArgumentException() : throw new ArgumentException();
            (ushort.TryParse(timeParts[3],out zmienna)?(zmienna<1000)?_milliseconds = zmienna : throw new ArgumentException() : throw new ArgumentException();
        }
        
        
        public override string ToString() { return $"{_hours:D2}:{_minutes:D2}:{_seconds:D2}:{_milliseconds:D2}"; }
        
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
        
        


    }//koniec struktury Time
}//Koniec przestrzeni nazw 
