namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.Stun)]
    public class StunBehaviorBase : BehaviorBase
    {
        [Parameter("cant_attack")]
        public bool CantAttack { get; set; }
        
        [Parameter("cant_equip")]
        public bool CantEquip { get; set; }
        
        [Parameter("cant_interact")]
        public bool CantInteract { get; set; }
        
        [Parameter("cant_move")]
        public bool CantMove { get; set; }
        
        [Parameter("cant_turn")]
        public bool CantTurn { get; set; }
        
        [Parameter("stun_caster")]
        public bool StunCaster { get; set; }
    }
}