namespace Business
{
    class GateControl : IGateControl
    {
        private readonly string _portCode;
        private readonly int _boundRate;

        public GateControl()
        {
            _boundRate = 9600;
            _portCode = "/dev/ttyACM0";
        }
        
        public void Open()
        {
            $"echo 1 > {_portCode}".Bash();
        }

        public void Close()
        {
            $"echo 0 > {_portCode}".Bash();
        }
    }
}