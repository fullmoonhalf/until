using until.system;


namespace until.test3
{
    public class ModeIngameSetup : Mode
    {
        #region definitions
        #endregion

        #region fields
        #endregion

        #region methods.
        #region mode
        public Mode.Control init()
        {
#if TEST
            Singleton.DevelopIndicator.regist(Singleton.ContextManager);
            utils.algorithm.Test.testPriorityQueue();
            utils.algorithm.Test.testAstar();
#endif
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            var location_aggregator = new LocationAggregator();
            Singleton.AkashicRecords.bind(location_aggregator);

            var area = new PseudoLocationAreaControl(1);
            location_aggregator.regist(area);

            // setup.
            for (var index = 0; index < 2; ++index)
            {
                var character = new TestCharacterContext();
                Singleton.ContextManager.regist(character);
                var locator = new PseudoMobileLocator(area.Area);
                area.regist(locator);
                character.bind(locator);

                var action = new TestCharacterActionWait(character);
                Singleton.ContextManager.regist(action);
            }

            // mode transition.
            Singleton.ModeManager.enqueueNextMode<ModeIngameRunning>();
            return Mode.Control.Done;
        }

        public Mode.Control exit()
        {
            return Mode.Control.Done;
        }
        #endregion
        #endregion
    }

}

