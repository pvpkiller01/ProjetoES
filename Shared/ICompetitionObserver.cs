namespace ESProjeto.Client
{
    public interface ICompetitionObserver
    {
        public void Subscribe(IObserver observer);
        public void Unsubscribe(IObserver observer);
        public void NotifyObservers();
    }
}
