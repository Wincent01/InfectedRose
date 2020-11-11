using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum PSLoopBehavior : uint
	{
		/// <summary>
		/// Key times map such that the first key occurs at the birth of the particle, and times later than the last key get the last key value.
		/// </summary>
		
		PS_LOOP_CLAMP_BIRTH = 0,
		/// <summary>
		/// Key times map such that the last key occurs at the death of the particle, and times before the initial key time get the value of the initial key.
		/// </summary>
		
		PS_LOOP_CLAMP_DEATH = 1,
		/// <summary>
		/// Scale the animation to fit the particle lifetime, so that the first key is age zero, and the last key comes at the particle death.
		/// </summary>
		
		PS_LOOP_AGESCALE = 2,
		/// <summary>
		/// The time is converted to one within the time range represented by the keys, as if the key sequence loops forever in the past and future.
		/// </summary>
		
		PS_LOOP_LOOP = 3,
		/// <summary>
		/// The time is reflection looped, as if the keys played forward then backward the forward then backward etc for all time.
		/// </summary>
		
		PS_LOOP_REFLECT = 4,
	}
	

}
