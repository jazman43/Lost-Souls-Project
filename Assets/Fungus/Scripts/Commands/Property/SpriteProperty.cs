// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

/*This script has been, partially or completely, generated by the Fungus.GenerateVariableWindow*/
using UnityEngine;

namespace Fungus
{
    // <summary>
    /// Get or Set a property of a Sprite component
    /// </summary>
    [CommandInfo("Property",
                 "Sprite",
                 "Get or Set a property of a Sprite component")]
    [AddComponentMenu("")]
    public class SpriteProperty : BaseVariableProperty
    {
		//generated property
        public enum Property 
        { 
            Border, 
            PixelsPerUnit, 
            Pivot, 
            Packed, 
            TextureRectOffset, 
            SpriteAtlasTextureScale, 
        }


        [SerializeField]
        protected Property property;

        [SerializeField]
        protected SpriteData spriteData;

        [SerializeField]
        [VariableProperty(typeof(Vector4Variable),
                          typeof(FloatVariable),
                          typeof(Vector2Variable),
                          typeof(BooleanVariable))]
        protected Variable inOutVar;

        public override void OnEnter()
        {
            var iov4 = inOutVar as Vector4Variable;
            var iof = inOutVar as FloatVariable;
            var iov2 = inOutVar as Vector2Variable;
            var iob = inOutVar as BooleanVariable;


            var target = spriteData.Value;

            switch (getOrSet)
            {
                case GetSet.Get:
                    switch (property)
                    {
                        case Property.Border:
                            iov4.Value = target.border;
                            break;
                        case Property.PixelsPerUnit:
                            iof.Value = target.pixelsPerUnit;
                            break;
                        case Property.SpriteAtlasTextureScale:
                            iof.Value = target.spriteAtlasTextureScale;
                            break;
                        case Property.Pivot:
                            iov2.Value = target.pivot;
                            break;
                        case Property.Packed:
                            iob.Value = target.packed;
                            break;
                        case Property.TextureRectOffset:
                            iov2.Value = target.textureRectOffset;
                            break;
                        default:
                            Debug.Log("Unsupported get or set attempted");
                            break;
                    }

                    break;

                case GetSet.Set:
                    switch (property)
                    {
                        default:
                            Debug.Log("Unsupported get or set attempted");
                            break;
                    }

                    break;

                default:
                    break;
            }

            spriteData.Value = target;

            Continue();
        }

        public override string GetSummary()
        {
            if (spriteData.Value == null)
            {
                return "Error: no sprite set";
            }
            if (inOutVar == null)
            {
                return "Error: no variable set to push or pull data to or from";
            }

            return getOrSet.ToString() + " " + property.ToString();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        public override bool HasReference(Variable variable)
        {
            if (spriteData.spriteRef == variable || inOutVar == variable)
                return true;

            return false;
        }
    }
}