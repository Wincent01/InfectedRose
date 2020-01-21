namespace InfectedRose.Database.Concepts.Tables
{
    public class VehiclePhysicsTable

    {
        public VehiclePhysicsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string hkxFilename
        {
            get => (string) Column["hkxFilename"].Value;

            set => Column["hkxFilename"].Value = value;
        }

        public float fGravityScale
        {
            get => (float) Column["fGravityScale"].Value;

            set => Column["fGravityScale"].Value = value;
        }

        public float fMass
        {
            get => (float) Column["fMass"].Value;

            set => Column["fMass"].Value = value;
        }

        public float fChassisFriction
        {
            get => (float) Column["fChassisFriction"].Value;

            set => Column["fChassisFriction"].Value = value;
        }

        public float fMaxSpeed
        {
            get => (float) Column["fMaxSpeed"].Value;

            set => Column["fMaxSpeed"].Value = value;
        }

        public float fEngineTorque
        {
            get => (float) Column["fEngineTorque"].Value;

            set => Column["fEngineTorque"].Value = value;
        }

        public float fBrakeFrontTorque
        {
            get => (float) Column["fBrakeFrontTorque"].Value;

            set => Column["fBrakeFrontTorque"].Value = value;
        }

        public float fBrakeRearTorque
        {
            get => (float) Column["fBrakeRearTorque"].Value;

            set => Column["fBrakeRearTorque"].Value = value;
        }

        public float fBrakeMinInputToBlock
        {
            get => (float) Column["fBrakeMinInputToBlock"].Value;

            set => Column["fBrakeMinInputToBlock"].Value = value;
        }

        public float fBrakeMinTimeToBlock
        {
            get => (float) Column["fBrakeMinTimeToBlock"].Value;

            set => Column["fBrakeMinTimeToBlock"].Value = value;
        }

        public float fSteeringMaxAngle
        {
            get => (float) Column["fSteeringMaxAngle"].Value;

            set => Column["fSteeringMaxAngle"].Value = value;
        }

        public float fSteeringSpeedLimitForMaxAngle
        {
            get => (float) Column["fSteeringSpeedLimitForMaxAngle"].Value;

            set => Column["fSteeringSpeedLimitForMaxAngle"].Value = value;
        }

        public float fSteeringMinAngle
        {
            get => (float) Column["fSteeringMinAngle"].Value;

            set => Column["fSteeringMinAngle"].Value = value;
        }

        public float fFwdBias
        {
            get => (float) Column["fFwdBias"].Value;

            set => Column["fFwdBias"].Value = value;
        }

        public float fFrontTireFriction
        {
            get => (float) Column["fFrontTireFriction"].Value;

            set => Column["fFrontTireFriction"].Value = value;
        }

        public float fRearTireFriction
        {
            get => (float) Column["fRearTireFriction"].Value;

            set => Column["fRearTireFriction"].Value = value;
        }

        public float fFrontTireFrictionSlide
        {
            get => (float) Column["fFrontTireFrictionSlide"].Value;

            set => Column["fFrontTireFrictionSlide"].Value = value;
        }

        public float fRearTireFrictionSlide
        {
            get => (float) Column["fRearTireFrictionSlide"].Value;

            set => Column["fRearTireFrictionSlide"].Value = value;
        }

        public float fFrontTireSlipAngle
        {
            get => (float) Column["fFrontTireSlipAngle"].Value;

            set => Column["fFrontTireSlipAngle"].Value = value;
        }

        public float fRearTireSlipAngle
        {
            get => (float) Column["fRearTireSlipAngle"].Value;

            set => Column["fRearTireSlipAngle"].Value = value;
        }

        public float fWheelWidth
        {
            get => (float) Column["fWheelWidth"].Value;

            set => Column["fWheelWidth"].Value = value;
        }

        public float fWheelRadius
        {
            get => (float) Column["fWheelRadius"].Value;

            set => Column["fWheelRadius"].Value = value;
        }

        public float fWheelMass
        {
            get => (float) Column["fWheelMass"].Value;

            set => Column["fWheelMass"].Value = value;
        }

        public float fReorientPitchStrength
        {
            get => (float) Column["fReorientPitchStrength"].Value;

            set => Column["fReorientPitchStrength"].Value = value;
        }

        public float fReorientRollStrength
        {
            get => (float) Column["fReorientRollStrength"].Value;

            set => Column["fReorientRollStrength"].Value = value;
        }

        public float fSuspensionLength
        {
            get => (float) Column["fSuspensionLength"].Value;

            set => Column["fSuspensionLength"].Value = value;
        }

        public float fSuspensionStrength
        {
            get => (float) Column["fSuspensionStrength"].Value;

            set => Column["fSuspensionStrength"].Value = value;
        }

        public float fSuspensionDampingCompression
        {
            get => (float) Column["fSuspensionDampingCompression"].Value;

            set => Column["fSuspensionDampingCompression"].Value = value;
        }

        public float fSuspensionDampingRelaxation
        {
            get => (float) Column["fSuspensionDampingRelaxation"].Value;

            set => Column["fSuspensionDampingRelaxation"].Value = value;
        }

        public int iChassisCollisionGroup
        {
            get => (int) Column["iChassisCollisionGroup"].Value;

            set => Column["iChassisCollisionGroup"].Value = value;
        }

        public float fNormalSpinDamping
        {
            get => (float) Column["fNormalSpinDamping"].Value;

            set => Column["fNormalSpinDamping"].Value = value;
        }

        public float fCollisionSpinDamping
        {
            get => (float) Column["fCollisionSpinDamping"].Value;

            set => Column["fCollisionSpinDamping"].Value = value;
        }

        public float fCollisionThreshold
        {
            get => (float) Column["fCollisionThreshold"].Value;

            set => Column["fCollisionThreshold"].Value = value;
        }

        public float fTorqueRollFactor
        {
            get => (float) Column["fTorqueRollFactor"].Value;

            set => Column["fTorqueRollFactor"].Value = value;
        }

        public float fTorquePitchFactor
        {
            get => (float) Column["fTorquePitchFactor"].Value;

            set => Column["fTorquePitchFactor"].Value = value;
        }

        public float fTorqueYawFactor
        {
            get => (float) Column["fTorqueYawFactor"].Value;

            set => Column["fTorqueYawFactor"].Value = value;
        }

        public float fInertiaRoll
        {
            get => (float) Column["fInertiaRoll"].Value;

            set => Column["fInertiaRoll"].Value = value;
        }

        public float fInertiaPitch
        {
            get => (float) Column["fInertiaPitch"].Value;

            set => Column["fInertiaPitch"].Value = value;
        }

        public float fInertiaYaw
        {
            get => (float) Column["fInertiaYaw"].Value;

            set => Column["fInertiaYaw"].Value = value;
        }

        public float fExtraTorqueFactor
        {
            get => (float) Column["fExtraTorqueFactor"].Value;

            set => Column["fExtraTorqueFactor"].Value = value;
        }

        public float fCenterOfMassFwd
        {
            get => (float) Column["fCenterOfMassFwd"].Value;

            set => Column["fCenterOfMassFwd"].Value = value;
        }

        public float fCenterOfMassUp
        {
            get => (float) Column["fCenterOfMassUp"].Value;

            set => Column["fCenterOfMassUp"].Value = value;
        }

        public float fCenterOfMassRight
        {
            get => (float) Column["fCenterOfMassRight"].Value;

            set => Column["fCenterOfMassRight"].Value = value;
        }

        public float fWheelHardpointFrontFwd
        {
            get => (float) Column["fWheelHardpointFrontFwd"].Value;

            set => Column["fWheelHardpointFrontFwd"].Value = value;
        }

        public float fWheelHardpointFrontUp
        {
            get => (float) Column["fWheelHardpointFrontUp"].Value;

            set => Column["fWheelHardpointFrontUp"].Value = value;
        }

        public float fWheelHardpointFrontRight
        {
            get => (float) Column["fWheelHardpointFrontRight"].Value;

            set => Column["fWheelHardpointFrontRight"].Value = value;
        }

        public float fWheelHardpointRearFwd
        {
            get => (float) Column["fWheelHardpointRearFwd"].Value;

            set => Column["fWheelHardpointRearFwd"].Value = value;
        }

        public float fWheelHardpointRearUp
        {
            get => (float) Column["fWheelHardpointRearUp"].Value;

            set => Column["fWheelHardpointRearUp"].Value = value;
        }

        public float fWheelHardpointRearRight
        {
            get => (float) Column["fWheelHardpointRearRight"].Value;

            set => Column["fWheelHardpointRearRight"].Value = value;
        }

        public float fInputTurnSpeed
        {
            get => (float) Column["fInputTurnSpeed"].Value;

            set => Column["fInputTurnSpeed"].Value = value;
        }

        public float fInputDeadTurnBackSpeed
        {
            get => (float) Column["fInputDeadTurnBackSpeed"].Value;

            set => Column["fInputDeadTurnBackSpeed"].Value = value;
        }

        public float fInputAccelSpeed
        {
            get => (float) Column["fInputAccelSpeed"].Value;

            set => Column["fInputAccelSpeed"].Value = value;
        }

        public float fInputDeadAccelDownSpeed
        {
            get => (float) Column["fInputDeadAccelDownSpeed"].Value;

            set => Column["fInputDeadAccelDownSpeed"].Value = value;
        }

        public float fInputDecelSpeed
        {
            get => (float) Column["fInputDecelSpeed"].Value;

            set => Column["fInputDecelSpeed"].Value = value;
        }

        public float fInputDeadDecelDownSpeed
        {
            get => (float) Column["fInputDeadDecelDownSpeed"].Value;

            set => Column["fInputDeadDecelDownSpeed"].Value = value;
        }

        public float fInputSlopeChangePointX
        {
            get => (float) Column["fInputSlopeChangePointX"].Value;

            set => Column["fInputSlopeChangePointX"].Value = value;
        }

        public float fInputInitialSlope
        {
            get => (float) Column["fInputInitialSlope"].Value;

            set => Column["fInputInitialSlope"].Value = value;
        }

        public float fInputDeadZone
        {
            get => (float) Column["fInputDeadZone"].Value;

            set => Column["fInputDeadZone"].Value = value;
        }

        public float fAeroAirDensity
        {
            get => (float) Column["fAeroAirDensity"].Value;

            set => Column["fAeroAirDensity"].Value = value;
        }

        public float fAeroFrontalArea
        {
            get => (float) Column["fAeroFrontalArea"].Value;

            set => Column["fAeroFrontalArea"].Value = value;
        }

        public float fAeroDragCoefficient
        {
            get => (float) Column["fAeroDragCoefficient"].Value;

            set => Column["fAeroDragCoefficient"].Value = value;
        }

        public float fAeroLiftCoefficient
        {
            get => (float) Column["fAeroLiftCoefficient"].Value;

            set => Column["fAeroLiftCoefficient"].Value = value;
        }

        public float fAeroExtraGravity
        {
            get => (float) Column["fAeroExtraGravity"].Value;

            set => Column["fAeroExtraGravity"].Value = value;
        }

        public float fBoostTopSpeed
        {
            get => (float) Column["fBoostTopSpeed"].Value;

            set => Column["fBoostTopSpeed"].Value = value;
        }

        public float fBoostCostPerSecond
        {
            get => (float) Column["fBoostCostPerSecond"].Value;

            set => Column["fBoostCostPerSecond"].Value = value;
        }

        public float fBoostAccelerateChange
        {
            get => (float) Column["fBoostAccelerateChange"].Value;

            set => Column["fBoostAccelerateChange"].Value = value;
        }

        public float fBoostDampingChange
        {
            get => (float) Column["fBoostDampingChange"].Value;

            set => Column["fBoostDampingChange"].Value = value;
        }

        public float fPowerslideNeutralAngle
        {
            get => (float) Column["fPowerslideNeutralAngle"].Value;

            set => Column["fPowerslideNeutralAngle"].Value = value;
        }

        public float fPowerslideTorqueStrength
        {
            get => (float) Column["fPowerslideTorqueStrength"].Value;

            set => Column["fPowerslideTorqueStrength"].Value = value;
        }

        public int iPowerslideNumTorqueApplications
        {
            get => (int) Column["iPowerslideNumTorqueApplications"].Value;

            set => Column["iPowerslideNumTorqueApplications"].Value = value;
        }

        public float fImaginationTankSize
        {
            get => (float) Column["fImaginationTankSize"].Value;

            set => Column["fImaginationTankSize"].Value = value;
        }

        public float fSkillCost
        {
            get => (float) Column["fSkillCost"].Value;

            set => Column["fSkillCost"].Value = value;
        }

        public float fWreckSpeedBase
        {
            get => (float) Column["fWreckSpeedBase"].Value;

            set => Column["fWreckSpeedBase"].Value = value;
        }

        public float fWreckSpeedPercent
        {
            get => (float) Column["fWreckSpeedPercent"].Value;

            set => Column["fWreckSpeedPercent"].Value = value;
        }

        public float fWreckMinAngle
        {
            get => (float) Column["fWreckMinAngle"].Value;

            set => Column["fWreckMinAngle"].Value = value;
        }

        public string AudioEventEngine
        {
            get => (string) Column["AudioEventEngine"].Value;

            set => Column["AudioEventEngine"].Value = value;
        }

        public string AudioEventSkid
        {
            get => (string) Column["AudioEventSkid"].Value;

            set => Column["AudioEventSkid"].Value = value;
        }

        public string AudioEventLightHit
        {
            get => (string) Column["AudioEventLightHit"].Value;

            set => Column["AudioEventLightHit"].Value = value;
        }

        public float AudioSpeedThresholdLightHit
        {
            get => (float) Column["AudioSpeedThresholdLightHit"].Value;

            set => Column["AudioSpeedThresholdLightHit"].Value = value;
        }

        public float AudioTimeoutLightHit
        {
            get => (float) Column["AudioTimeoutLightHit"].Value;

            set => Column["AudioTimeoutLightHit"].Value = value;
        }

        public string AudioEventHeavyHit
        {
            get => (string) Column["AudioEventHeavyHit"].Value;

            set => Column["AudioEventHeavyHit"].Value = value;
        }

        public float AudioSpeedThresholdHeavyHit
        {
            get => (float) Column["AudioSpeedThresholdHeavyHit"].Value;

            set => Column["AudioSpeedThresholdHeavyHit"].Value = value;
        }

        public float AudioTimeoutHeavyHit
        {
            get => (float) Column["AudioTimeoutHeavyHit"].Value;

            set => Column["AudioTimeoutHeavyHit"].Value = value;
        }

        public string AudioEventStart
        {
            get => (string) Column["AudioEventStart"].Value;

            set => Column["AudioEventStart"].Value = value;
        }

        public string AudioEventTreadConcrete
        {
            get => (string) Column["AudioEventTreadConcrete"].Value;

            set => Column["AudioEventTreadConcrete"].Value = value;
        }

        public string AudioEventTreadSand
        {
            get => (string) Column["AudioEventTreadSand"].Value;

            set => Column["AudioEventTreadSand"].Value = value;
        }

        public string AudioEventTreadWood
        {
            get => (string) Column["AudioEventTreadWood"].Value;

            set => Column["AudioEventTreadWood"].Value = value;
        }

        public string AudioEventTreadDirt
        {
            get => (string) Column["AudioEventTreadDirt"].Value;

            set => Column["AudioEventTreadDirt"].Value = value;
        }

        public string AudioEventTreadPlastic
        {
            get => (string) Column["AudioEventTreadPlastic"].Value;

            set => Column["AudioEventTreadPlastic"].Value = value;
        }

        public string AudioEventTreadGrass
        {
            get => (string) Column["AudioEventTreadGrass"].Value;

            set => Column["AudioEventTreadGrass"].Value = value;
        }

        public string AudioEventTreadGravel
        {
            get => (string) Column["AudioEventTreadGravel"].Value;

            set => Column["AudioEventTreadGravel"].Value = value;
        }

        public string AudioEventTreadMud
        {
            get => (string) Column["AudioEventTreadMud"].Value;

            set => Column["AudioEventTreadMud"].Value = value;
        }

        public string AudioEventTreadWater
        {
            get => (string) Column["AudioEventTreadWater"].Value;

            set => Column["AudioEventTreadWater"].Value = value;
        }

        public string AudioEventTreadSnow
        {
            get => (string) Column["AudioEventTreadSnow"].Value;

            set => Column["AudioEventTreadSnow"].Value = value;
        }

        public string AudioEventTreadIce
        {
            get => (string) Column["AudioEventTreadIce"].Value;

            set => Column["AudioEventTreadIce"].Value = value;
        }

        public string AudioEventTreadMetal
        {
            get => (string) Column["AudioEventTreadMetal"].Value;

            set => Column["AudioEventTreadMetal"].Value = value;
        }

        public string AudioEventTreadLeaves
        {
            get => (string) Column["AudioEventTreadLeaves"].Value;

            set => Column["AudioEventTreadLeaves"].Value = value;
        }

        public string AudioEventLightLand
        {
            get => (string) Column["AudioEventLightLand"].Value;

            set => Column["AudioEventLightLand"].Value = value;
        }

        public float AudioAirtimeForLightLand
        {
            get => (float) Column["AudioAirtimeForLightLand"].Value;

            set => Column["AudioAirtimeForLightLand"].Value = value;
        }

        public string AudioEventHeavyLand
        {
            get => (string) Column["AudioEventHeavyLand"].Value;

            set => Column["AudioEventHeavyLand"].Value = value;
        }

        public float AudioAirtimeForHeavyLand
        {
            get => (float) Column["AudioAirtimeForHeavyLand"].Value;

            set => Column["AudioAirtimeForHeavyLand"].Value = value;
        }

        public bool bWheelsVisible
        {
            get => (bool) Column["bWheelsVisible"].Value;

            set => Column["bWheelsVisible"].Value = value;
        }
    }
}