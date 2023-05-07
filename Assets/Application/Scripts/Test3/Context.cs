namespace until.test3
{
    public class Context
    {
        #region Definition
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Methods
        #endregion

        #region Develop
#if TEST
        public virtual string DebugStatus
        {
            get => $"{GetType().Name}";
        }
#endif
        #endregion
    }
}
