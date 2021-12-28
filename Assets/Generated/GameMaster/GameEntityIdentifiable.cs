#if true
using until.modules.gamemaster;
using until.test;


namespace until.modules.gamemaster
{
public enum GameEntityIdentifiable
{
Invalid,
[GameEntityIdentifierValue(CharacterID.Invalid)]
until_test_CharacterID_Invalid,
[GameEntityIdentifierValue(CharacterID.Ch01000)]
until_test_CharacterID_Ch01000,
[GameEntityIdentifierValue(CharacterID.Ch12000)]
until_test_CharacterID_Ch12000,
[GameEntityIdentifierValue(PropsID.prop_80_000)]
until_test_PropsID_prop_80_000,
[GameEntityIdentifierValue(PropsID.Invalid)]
until_test_PropsID_Invalid,
[GameEntityIdentifierValue(LevelID.lv_003_001_00)]
until_test_StageID_lv_003_001_00,
[GameEntityIdentifierValue(LevelID.Invalid)]
until_test_StageID_Invalid,

}
}
#endif
