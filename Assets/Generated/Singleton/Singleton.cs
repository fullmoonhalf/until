#if true
public class Singleton
{
    public static until.system.BootSystem BootSystem = until.system.BootSystem.Instance;
    public static until.system.GameObjectControlMediator GameObjectControlMediator = until.system.GameObjectControlMediator.Instance;
    public static until.system.InputManager InputManager = until.system.InputManager.Instance;
    public static until.system.ModeManager ModeManager = until.system.ModeManager.Instance;
    public static until.system.PrefabInstantiateMediator PrefabInstantiateMediator = until.system.PrefabInstantiateMediator.Instance;
    public static until.system.SceneLoader SceneLoader = until.system.SceneLoader.Instance;
    public static until.system.RandomizerManager RandomizerManager = until.system.RandomizerManager.Instance;
    public static until.modules.gamefield.IngameField IngameField = until.modules.gamefield.IngameField.Instance;
    public static until.modules.gamefield.StageSceneManager StageSceneManager = until.modules.gamefield.StageSceneManager.Instance;
    public static until.modules.gamefield.StageSetupper StageSetupper = until.modules.gamefield.StageSetupper.Instance;
    public static until.modules.gamefield.SubstanceManager SubstanceManager = until.modules.gamefield.SubstanceManager.Instance;
    public static until.modules.camera.CameraManager CameraManager = until.modules.camera.CameraManager.Instance;
    public static until.modules.bullet.BulletManager BulletManager = until.modules.bullet.BulletManager.Instance;
    public static until.modules.astral.AstralManager AstralManager = until.modules.astral.AstralManager.Instance;
    public static until.modules.gamemaster.GameMaster GameMaster = until.modules.gamemaster.GameMaster.Instance;
    public static until.test.AppAstralWorldDatabase AppAstralWorldDatabase = until.test.AppAstralWorldDatabase.Instance;
    public static until.test3.ContextManager ContextManager = until.test3.ContextManager.Instance;
    public static until.test3.AkashicRecords AkashicRecords = until.test3.AkashicRecords.Instance;
#if TEST
    public static until.develop.DevelopCommandManager DevelopCommandManager = until.develop.DevelopCommandManager.Instance;
    public static until.develop.DevelopIndicator DevelopIndicator = until.develop.DevelopIndicator.Instance;
#endif
}
#endif
