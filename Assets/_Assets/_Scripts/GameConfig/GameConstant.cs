using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant 
{
    #region GameTag Constant
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string GROUND_TAG = "Ground";
    public const string INTERACTABLE_TAG = "Interactable";
    public const string PLAYERHITLAYER_TAG = "PlayerHit";
    public const string ENEMYHITLAYER_TAG = "EnemyHit";
    #endregion

    #region PlayerAnimation Constant
    public const string PLAYER_IDLE_ANIM = "main_idle";
    public const string PLAYER_WALK_ANIM = "main_walk";
    public const string PLAYER_JUMP_ANIM = "main_jump";
    public const string PLAYER_FALL_ANIM = "main_fall";
    public const string PLAYER_GET_HIT_ANIM = "main_hurt";
    public const string PLAYER_DEAD_ANIM = "main_dead";
    public const string PLAYER_SLIDE_ANIM = "main_slide";
    public const string PLAYER_ENTRY_ATTACK_ANIM = "main_attack_1";
    public const string PLAYER_COMBO_ATTACK1_ANIM = "main_attack_2";
    public const string PLAYER_COMBO_ATTACK2_ANIM = "main_attack_3";
    public const string PLAYER_FINISH_ATTACK_ANIM = "main_attack_4";
    public const string PLAYER_AIR_ATTACK_ANIM = "main_attackFromAir";
    public const string PLAYER_AIR_ATTACK_GROUNDED_ANIM = "main_attackFromAir_grounded";
    public const string PLAYER_HEAL_ANIM = "main_heal";

    #endregion

    #region BossAnimation Constant
    public const string BOSS_IDLE_ANIM = "BOSS_IDLE_ANIM";    
    public const string BOSS_ATTACK_ANIM = "BOSS_MELEE_ANIM";    
    public const string BOSS_SPELL_ANIM = "BOSS_CAST_ANIM";
    public const string BOSS_WALK_ANIM = "BOSS_WALK_ANIM";
    public const string BOSS_HURT_ANIM = "BOSS_HURT_ANIM";
    public const string BOSS_DEAD_ANIM = "BOSS_DED_ANIM";
   
    

    #endregion

    #region GameNotificationText Constant
    public const string INSUFFICENT_COIN_TEXT = "Insufficent Coin";
    public const string INVENTORY_FULL_TEXT = "Inventory full";
    public const string INVENTORY_BUFF_ITEM_TEXT = "Only can equid one active item at once";
    #endregion
}
