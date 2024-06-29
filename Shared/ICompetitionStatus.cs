using ESProjeto.Shared;

namespace ESProjeto.Shared
{ 
    public interface ICompetitionStatus
    {
        public bool IsStarted { get; }
        public bool IsFinished { get; }
        public bool IsSuspended { get; }

        public void Start();
        public void Finish();
        public void Suspend();

    }
}