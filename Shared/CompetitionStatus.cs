namespace ESProjeto.Shared
{
    public class CompetitionStatus : ICompetitionStatus
    {
        private bool _isStarted;
        private bool _isFinished;
        private bool _isSuspended;

        public bool IsStarted { get { return _isStarted; } }

        public bool IsFinished { get { return _isFinished; } }

        public bool IsSuspended { get { return _isSuspended; } }

        public void Start()
        {
            _isSuspended = false;
            _isFinished = false;
            _isStarted = true;

        }
        public void Finish()
        {
            _isSuspended = false;
            _isFinished = true;
            _isStarted = false;
        }
        public void Suspend()
        {
            _isSuspended = true;
            _isFinished = false;
            _isStarted = false;
        }

    }
}

