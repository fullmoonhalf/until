using System.Collections.Generic;
using until.system;


namespace until.test3
{
    public class AkashicRecords : Singleton<AkashicRecords>
    {
        #region Definition
        #endregion

        #region Properties
        public LocationAggregator Location { get; private set; } = null;
        #endregion

        #region Fields
        #endregion

        #region Methods
        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
        }
        #endregion

        #region bind
        public void bind(LocationAggregator location)
        {
            Location = location;
        }
        #endregion

        #endregion

        #region Develop
#if TEST
        public virtual string DevelopExpression
        {
            get => $"{GetType().Name}";
        }
#endif
        #endregion
    }
}
