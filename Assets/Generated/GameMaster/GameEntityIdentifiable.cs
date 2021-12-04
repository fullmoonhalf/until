#if true
using until.modules.gamemaster;
using until.test;


public enum GameEntityIdentifiable
{
Invalid,
[GameEntityIdentifierValue(CharacterID.Invalid)]
until_test_CharacterID_Invalid,
[GameEntityIdentifierValue(CharacterID.Ch1000)]
until_test_CharacterID_Ch1000,
[GameEntityIdentifierValue(CharacterID.Ch1001)]
until_test_CharacterID_Ch1001,

}
#endif
