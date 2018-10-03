using InfernalRobotics.Module;
using LmpClient.Events;
using UnityEngine;

namespace LmpIrPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class LmpIrPlugin : MonoBehaviour
    {
        public static LmpIrPlugin Singleton { get; set; }

        public void Awake()
        {
            Singleton = this;
            DontDestroyOnLoad(this);

            Debug.Log("[LmpIRPlugin] LMP-IR Plugin started!");

            PartModuleEvent.onPartModuleBoolFieldProcessed.Add(PartModuleBoolFieldChanged);
            PartModuleEvent.onPartModuleIntFieldProcessed.Add(PartModuleIntFieldChanged);
            PartModuleEvent.onPartModuleFloatFieldProcessed.Add(PartModuleFloatFieldChanged);
            PartModuleEvent.onPartModuleDoubleFieldProcessed.Add(PartModuleDoubleFieldChanged);
            PartModuleEvent.onPartModuleVectorFieldProcessed.Add(PartModuleVectorFieldChanged);
            PartModuleEvent.onPartModuleQuaternionFieldProcessed.Add(PartModuleQuaternionFieldChanged);
            PartModuleEvent.onPartModuleStringFieldProcessed.Add(PartModuleStringFieldChanged);
            PartModuleEvent.onPartModuleObjectFieldProcessed.Add(PartModuleObjectFieldChanged);
            PartModuleEvent.onPartModuleEnumFieldProcessed.Add(PartModuleEnumFieldChanged);
        }

        private void PartModuleEnumFieldChanged(ProtoPartModuleSnapshot module, string field, int value, string data3)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleObjectFieldChanged(ProtoPartModuleSnapshot module, string field, object value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleStringFieldChanged(ProtoPartModuleSnapshot module, string field, string value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleQuaternionFieldChanged(ProtoPartModuleSnapshot module, string field, Quaternion value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleVectorFieldChanged(ProtoPartModuleSnapshot module, string field, Vector3 value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleDoubleFieldChanged(ProtoPartModuleSnapshot module, string field, double value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleFloatFieldChanged(ProtoPartModuleSnapshot module, string field, float value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleIntFieldChanged(ProtoPartModuleSnapshot module, string field, int value)
        {
            UpdatePartPos(module, field, value);
        }

        private void PartModuleBoolFieldChanged(ProtoPartModuleSnapshot module, string field, bool value)
        {
            UpdatePartPos(module, field, value);
        }

        private void UpdatePartPos(ProtoPartModuleSnapshot module, string fieldName, object value)
        {
            if (module.moduleRef != null && module.moduleRef is ModuleIRServo)
            {
                module.moduleRef.Fields[fieldName].SetValue(value, module.moduleRef);
                module.moduleRef.OnStart(PartModule.StartState.None);
            }
        }
    }
}
