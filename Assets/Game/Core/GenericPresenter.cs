namespace Game.Core
{
    public abstract class GenericPresenter<T> where T : IView
    {
        protected T View { get; private set; }

        public virtual void Mount(T view)
        {
            View = view;
        }

        public virtual void Unmount()
        {
        }
    }
}