/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace DotNetHack.RPC
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class DamageDescriptor : TBase
  {
    private BodyRegion _bodyRegion;
    private InjurySeverityScore _severity;

    /// <summary>
    /// 
    /// <seealso cref="BodyRegion"/>
    /// </summary>
    public BodyRegion BodyRegion
    {
      get
      {
        return _bodyRegion;
      }
      set
      {
        __isset.bodyRegion = true;
        this._bodyRegion = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref="InjurySeverityScore"/>
    /// </summary>
    public InjurySeverityScore Severity
    {
      get
      {
        return _severity;
      }
      set
      {
        __isset.severity = true;
        this._severity = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool bodyRegion;
      public bool severity;
    }

    public DamageDescriptor() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32) {
              BodyRegion = (BodyRegion)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              Severity = (InjurySeverityScore)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("DamageDescriptor");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.bodyRegion) {
        field.Name = "bodyRegion";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)BodyRegion);
        oprot.WriteFieldEnd();
      }
      if (__isset.severity) {
        field.Name = "severity";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)Severity);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DamageDescriptor(");
      sb.Append("BodyRegion: ");
      sb.Append(BodyRegion);
      sb.Append(",Severity: ");
      sb.Append(Severity);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
