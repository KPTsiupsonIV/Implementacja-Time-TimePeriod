namespace Time
{
    public struct Time
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
            _hours = !(hours <= 24) ? _hours = hours : throw new ArgumentException();
            _minutes = 0;
            _seconds = 0;
            _milliseconds = 0;
        }
        public Time(string czas)
        {
            //dopisac sprawdzanie parsowania
            string[] timeParts = czas.Split(':');
            _hours = byte.Parse(timeParts[0]);
            _minutes = byte.Parse(timeParts[1]);
            _seconds = byte.Parse(timeParts[2]);
            _milliseconds = ushort.Parse(timeParts[3]);
        }
        public override string ToString() { return $"{_hours:D2}:{_minutes:D2}:{_seconds:D2}:{_milliseconds:D2}"; }



    }//koniec struktury Time
}//Koniec przestrzeni nazw 