using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Sets mesh color in Oblivion Construction Set.  Anything higher than 57 is also null.
	///         
	/// </summary>
	public enum OblivionLayer : byte
	{
		/// <summary>
		/// Unidentified (white)
		/// </summary>
		
		OL_UNIDENTIFIED = 0,
		/// <summary>
		/// Static (red)
		/// </summary>
		
		OL_STATIC = 1,
		/// <summary>
		/// AnimStatic (magenta)
		/// </summary>
		
		OL_ANIM_STATIC = 2,
		/// <summary>
		/// Transparent (light pink)
		/// </summary>
		
		OL_TRANSPARENT = 3,
		/// <summary>
		/// Clutter (light blue)
		/// </summary>
		
		OL_CLUTTER = 4,
		/// <summary>
		/// Weapon (orange)
		/// </summary>
		
		OL_WEAPON = 5,
		/// <summary>
		/// Projectile (light orange)
		/// </summary>
		
		OL_PROJECTILE = 6,
		/// <summary>
		/// Spell (cyan)
		/// </summary>
		
		OL_SPELL = 7,
		/// <summary>
		/// Biped (green) Seems to apply to all creatures/NPCs
		/// </summary>
		
		OL_BIPED = 8,
		/// <summary>
		/// Trees (light brown)
		/// </summary>
		
		OL_TREES = 9,
		/// <summary>
		/// Props (magenta)
		/// </summary>
		
		OL_PROPS = 10,
		/// <summary>
		/// Water (cyan)
		/// </summary>
		
		OL_WATER = 11,
		/// <summary>
		/// Trigger (light grey)
		/// </summary>
		
		OL_TRIGGER = 12,
		/// <summary>
		/// Terrain (light yellow)
		/// </summary>
		
		OL_TERRAIN = 13,
		/// <summary>
		/// Trap (light grey)
		/// </summary>
		
		OL_TRAP = 14,
		/// <summary>
		/// NonCollidable (white)
		/// </summary>
		
		OL_NONCOLLIDABLE = 15,
		/// <summary>
		/// CloudTrap (greenish grey)
		/// </summary>
		
		OL_CLOUD_TRAP = 16,
		/// <summary>
		/// Ground (none)
		/// </summary>
		
		OL_GROUND = 17,
		/// <summary>
		/// Portal (green)
		/// </summary>
		
		OL_PORTAL = 18,
		/// <summary>
		/// Stairs (white)
		/// </summary>
		
		OL_STAIRS = 19,
		/// <summary>
		/// CharController (yellow)
		/// </summary>
		
		OL_CHAR_CONTROLLER = 20,
		/// <summary>
		/// AvoidBox (dark yellow)
		/// </summary>
		
		OL_AVOID_BOX = 21,
		/// <summary>
		/// ? (white)
		/// </summary>
		
		OL_UNKNOWN1 = 22,
		/// <summary>
		/// ? (white)
		/// </summary>
		
		OL_UNKNOWN2 = 23,
		/// <summary>
		/// CameraPick (white)
		/// </summary>
		
		OL_CAMERA_PICK = 24,
		/// <summary>
		/// ItemPick (white)
		/// </summary>
		
		OL_ITEM_PICK = 25,
		/// <summary>
		/// LineOfSight (white)
		/// </summary>
		
		OL_LINE_OF_SIGHT = 26,
		/// <summary>
		/// PathPick (white)
		/// </summary>
		
		OL_PATH_PICK = 27,
		/// <summary>
		/// CustomPick1 (white)
		/// </summary>
		
		OL_CUSTOM_PICK_1 = 28,
		/// <summary>
		/// CustomPick2 (white)
		/// </summary>
		
		OL_CUSTOM_PICK_2 = 29,
		/// <summary>
		/// SpellExplosion (white)
		/// </summary>
		
		OL_SPELL_EXPLOSION = 30,
		/// <summary>
		/// DroppingPick (white)
		/// </summary>
		
		OL_DROPPING_PICK = 31,
		/// <summary>
		/// Other (white)
		/// </summary>
		
		OL_OTHER = 32,
		/// <summary>
		/// Head
		/// </summary>
		
		OL_HEAD = 33,
		/// <summary>
		/// Body
		/// </summary>
		
		OL_BODY = 34,
		/// <summary>
		/// Spine1
		/// </summary>
		
		OL_SPINE1 = 35,
		/// <summary>
		/// Spine2
		/// </summary>
		
		OL_SPINE2 = 36,
		/// <summary>
		/// LUpperArm
		/// </summary>
		
		OL_L_UPPER_ARM = 37,
		/// <summary>
		/// LForeArm
		/// </summary>
		
		OL_L_FOREARM = 38,
		/// <summary>
		/// LHand
		/// </summary>
		
		OL_L_HAND = 39,
		/// <summary>
		/// LThigh
		/// </summary>
		
		OL_L_THIGH = 40,
		/// <summary>
		/// LCalf
		/// </summary>
		
		OL_L_CALF = 41,
		/// <summary>
		/// LFoot
		/// </summary>
		
		OL_L_FOOT = 42,
		/// <summary>
		/// RUpperArm
		/// </summary>
		
		OL_R_UPPER_ARM = 43,
		/// <summary>
		/// RForeArm
		/// </summary>
		
		OL_R_FOREARM = 44,
		/// <summary>
		/// RHand
		/// </summary>
		
		OL_R_HAND = 45,
		/// <summary>
		/// RThigh
		/// </summary>
		
		OL_R_THIGH = 46,
		/// <summary>
		/// RCalf
		/// </summary>
		
		OL_R_CALF = 47,
		/// <summary>
		/// RFoot
		/// </summary>
		
		OL_R_FOOT = 48,
		/// <summary>
		/// Tail
		/// </summary>
		
		OL_TAIL = 49,
		/// <summary>
		/// SideWeapon
		/// </summary>
		
		OL_SIDE_WEAPON = 50,
		/// <summary>
		/// Shield
		/// </summary>
		
		OL_SHIELD = 51,
		/// <summary>
		/// Quiver
		/// </summary>
		
		OL_QUIVER = 52,
		/// <summary>
		/// BackWeapon
		/// </summary>
		
		OL_BACK_WEAPON = 53,
		/// <summary>
		/// BackWeapon (?)
		/// </summary>
		
		OL_BACK_WEAPON2 = 54,
		/// <summary>
		/// PonyTail
		/// </summary>
		
		OL_PONYTAIL = 55,
		/// <summary>
		/// Wing
		/// </summary>
		
		OL_WING = 56,
		/// <summary>
		/// Null
		/// </summary>
		
		OL_NULL = 57,
	}
	

}
