/**
 * Autogenerated by Thrift Compiler (0.9.0)
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

public partial class DNHService {
  /// <summary>
  /// Description: The core DNh service.
  /// </summary>
  public interface Iface {
    DNHActionResult MoveTo(int playerId, int x, int y, int z);
    #if SILVERLIGHT
    IAsyncResult Begin_MoveTo(AsyncCallback callback, object state, int playerId, int x, int y, int z);
    DNHActionResult End_MoveTo(IAsyncResult asyncResult);
    #endif
    DNHActionResult Pickup(int playerId);
    #if SILVERLIGHT
    IAsyncResult Begin_Pickup(AsyncCallback callback, object state, int playerId);
    DNHActionResult End_Pickup(IAsyncResult asyncResult);
    #endif
    DNHActionResult DropItem(int playerId, int itemId);
    #if SILVERLIGHT
    IAsyncResult Begin_DropItem(AsyncCallback callback, object state, int playerId, int itemId);
    DNHActionResult End_DropItem(IAsyncResult asyncResult);
    #endif
  }

  /// <summary>
  /// Description: The core DNh service.
  /// </summary>
  public class Client : Iface {
    public Client(TProtocol prot) : this(prot, prot)
    {
    }

    public Client(TProtocol iprot, TProtocol oprot)
    {
      iprot_ = iprot;
      oprot_ = oprot;
    }

    protected TProtocol iprot_;
    protected TProtocol oprot_;
    protected int seqid_;

    public TProtocol InputProtocol
    {
      get { return iprot_; }
    }
    public TProtocol OutputProtocol
    {
      get { return oprot_; }
    }


    
    #if SILVERLIGHT
    public IAsyncResult Begin_MoveTo(AsyncCallback callback, object state, int playerId, int x, int y, int z)
    {
      return send_MoveTo(callback, state, playerId, x, y, z);
    }

    public DNHActionResult End_MoveTo(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_MoveTo();
    }

    #endif

    public DNHActionResult MoveTo(int playerId, int x, int y, int z)
    {
      #if !SILVERLIGHT
      send_MoveTo(playerId, x, y, z);
      return recv_MoveTo();

      #else
      var asyncResult = Begin_MoveTo(null, null, playerId, x, y, z);
      return End_MoveTo(asyncResult);

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_MoveTo(AsyncCallback callback, object state, int playerId, int x, int y, int z)
    #else
    public void send_MoveTo(int playerId, int x, int y, int z)
    #endif
    {
      oprot_.WriteMessageBegin(new TMessage("MoveTo", TMessageType.Call, seqid_));
      MoveTo_args args = new MoveTo_args();
      args.PlayerId = playerId;
      args.X = x;
      args.Y = y;
      args.Z = z;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      #if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
      oprot_.Transport.Flush();
      #endif
    }

    public DNHActionResult recv_MoveTo()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      MoveTo_result result = new MoveTo_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "MoveTo failed: unknown result");
    }

    
    #if SILVERLIGHT
    public IAsyncResult Begin_Pickup(AsyncCallback callback, object state, int playerId)
    {
      return send_Pickup(callback, state, playerId);
    }

    public DNHActionResult End_Pickup(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_Pickup();
    }

    #endif

    public DNHActionResult Pickup(int playerId)
    {
      #if !SILVERLIGHT
      send_Pickup(playerId);
      return recv_Pickup();

      #else
      var asyncResult = Begin_Pickup(null, null, playerId);
      return End_Pickup(asyncResult);

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_Pickup(AsyncCallback callback, object state, int playerId)
    #else
    public void send_Pickup(int playerId)
    #endif
    {
      oprot_.WriteMessageBegin(new TMessage("Pickup", TMessageType.Call, seqid_));
      Pickup_args args = new Pickup_args();
      args.PlayerId = playerId;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      #if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
      oprot_.Transport.Flush();
      #endif
    }

    public DNHActionResult recv_Pickup()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      Pickup_result result = new Pickup_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Pickup failed: unknown result");
    }

    
    #if SILVERLIGHT
    public IAsyncResult Begin_DropItem(AsyncCallback callback, object state, int playerId, int itemId)
    {
      return send_DropItem(callback, state, playerId, itemId);
    }

    public DNHActionResult End_DropItem(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_DropItem();
    }

    #endif

    public DNHActionResult DropItem(int playerId, int itemId)
    {
      #if !SILVERLIGHT
      send_DropItem(playerId, itemId);
      return recv_DropItem();

      #else
      var asyncResult = Begin_DropItem(null, null, playerId, itemId);
      return End_DropItem(asyncResult);

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_DropItem(AsyncCallback callback, object state, int playerId, int itemId)
    #else
    public void send_DropItem(int playerId, int itemId)
    #endif
    {
      oprot_.WriteMessageBegin(new TMessage("DropItem", TMessageType.Call, seqid_));
      DropItem_args args = new DropItem_args();
      args.PlayerId = playerId;
      args.ItemId = itemId;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      #if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
      oprot_.Transport.Flush();
      #endif
    }

    public DNHActionResult recv_DropItem()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      DropItem_result result = new DropItem_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "DropItem failed: unknown result");
    }

  }
  public class Processor : TProcessor {
    public Processor(Iface iface)
    {
      iface_ = iface;
      processMap_["MoveTo"] = MoveTo_Process;
      processMap_["Pickup"] = Pickup_Process;
      processMap_["DropItem"] = DropItem_Process;
    }

    protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
    private Iface iface_;
    protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

    public bool Process(TProtocol iprot, TProtocol oprot)
    {
      try
      {
        TMessage msg = iprot.ReadMessageBegin();
        ProcessFunction fn;
        processMap_.TryGetValue(msg.Name, out fn);
        if (fn == null) {
          TProtocolUtil.Skip(iprot, TType.Struct);
          iprot.ReadMessageEnd();
          TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
          oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
          x.Write(oprot);
          oprot.WriteMessageEnd();
          oprot.Transport.Flush();
          return true;
        }
        fn(msg.SeqID, iprot, oprot);
      }
      catch (IOException)
      {
        return false;
      }
      return true;
    }

    public void MoveTo_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      MoveTo_args args = new MoveTo_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      MoveTo_result result = new MoveTo_result();
      result.Success = iface_.MoveTo(args.PlayerId, args.X, args.Y, args.Z);
      oprot.WriteMessageBegin(new TMessage("MoveTo", TMessageType.Reply, seqid)); 
      result.Write(oprot);
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

    public void Pickup_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      Pickup_args args = new Pickup_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      Pickup_result result = new Pickup_result();
      result.Success = iface_.Pickup(args.PlayerId);
      oprot.WriteMessageBegin(new TMessage("Pickup", TMessageType.Reply, seqid)); 
      result.Write(oprot);
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

    public void DropItem_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      DropItem_args args = new DropItem_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      DropItem_result result = new DropItem_result();
      result.Success = iface_.DropItem(args.PlayerId, args.ItemId);
      oprot.WriteMessageBegin(new TMessage("DropItem", TMessageType.Reply, seqid)); 
      result.Write(oprot);
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MoveTo_args : TBase
  {
    private int _playerId;
    private int _x;
    private int _y;
    private int _z;

    public int PlayerId
    {
      get
      {
        return _playerId;
      }
      set
      {
        __isset.playerId = true;
        this._playerId = value;
      }
    }

    public int X
    {
      get
      {
        return _x;
      }
      set
      {
        __isset.x = true;
        this._x = value;
      }
    }

    public int Y
    {
      get
      {
        return _y;
      }
      set
      {
        __isset.y = true;
        this._y = value;
      }
    }

    public int Z
    {
      get
      {
        return _z;
      }
      set
      {
        __isset.z = true;
        this._z = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool playerId;
      public bool x;
      public bool y;
      public bool z;
    }

    public MoveTo_args() {
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
              PlayerId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case -1:
            if (field.Type == TType.I32) {
              X = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case -2:
            if (field.Type == TType.I32) {
              Y = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case -3:
            if (field.Type == TType.I32) {
              Z = iprot.ReadI32();
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
      TStruct struc = new TStruct("MoveTo_args");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.z) {
        field.Name = "z";
        field.Type = TType.I32;
        field.ID = -3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Z);
        oprot.WriteFieldEnd();
      }
      if (__isset.y) {
        field.Name = "y";
        field.Type = TType.I32;
        field.ID = -2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Y);
        oprot.WriteFieldEnd();
      }
      if (__isset.x) {
        field.Name = "x";
        field.Type = TType.I32;
        field.ID = -1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(X);
        oprot.WriteFieldEnd();
      }
      if (__isset.playerId) {
        field.Name = "playerId";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PlayerId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MoveTo_args(");
      sb.Append("PlayerId: ");
      sb.Append(PlayerId);
      sb.Append(",X: ");
      sb.Append(X);
      sb.Append(",Y: ");
      sb.Append(Y);
      sb.Append(",Z: ");
      sb.Append(Z);
      sb.Append(")");
      return sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MoveTo_result : TBase
  {
    private DNHActionResult _success;

    public DNHActionResult Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
    }

    public MoveTo_result() {
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
          case 0:
            if (field.Type == TType.Struct) {
              Success = new DNHActionResult();
              Success.Read(iprot);
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
      TStruct struc = new TStruct("MoveTo_result");
      oprot.WriteStructBegin(struc);
      TField field = new TField();

      if (this.__isset.success) {
        if (Success != null) {
          field.Name = "Success";
          field.Type = TType.Struct;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          Success.Write(oprot);
          oprot.WriteFieldEnd();
        }
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MoveTo_result(");
      sb.Append("Success: ");
      sb.Append(Success== null ? "<null>" : Success.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Pickup_args : TBase
  {
    private int _playerId;

    public int PlayerId
    {
      get
      {
        return _playerId;
      }
      set
      {
        __isset.playerId = true;
        this._playerId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool playerId;
    }

    public Pickup_args() {
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
              PlayerId = iprot.ReadI32();
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
      TStruct struc = new TStruct("Pickup_args");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.playerId) {
        field.Name = "playerId";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PlayerId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Pickup_args(");
      sb.Append("PlayerId: ");
      sb.Append(PlayerId);
      sb.Append(")");
      return sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Pickup_result : TBase
  {
    private DNHActionResult _success;

    public DNHActionResult Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
    }

    public Pickup_result() {
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
          case 0:
            if (field.Type == TType.Struct) {
              Success = new DNHActionResult();
              Success.Read(iprot);
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
      TStruct struc = new TStruct("Pickup_result");
      oprot.WriteStructBegin(struc);
      TField field = new TField();

      if (this.__isset.success) {
        if (Success != null) {
          field.Name = "Success";
          field.Type = TType.Struct;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          Success.Write(oprot);
          oprot.WriteFieldEnd();
        }
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Pickup_result(");
      sb.Append("Success: ");
      sb.Append(Success== null ? "<null>" : Success.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class DropItem_args : TBase
  {
    private int _playerId;
    private int _itemId;

    public int PlayerId
    {
      get
      {
        return _playerId;
      }
      set
      {
        __isset.playerId = true;
        this._playerId = value;
      }
    }

    public int ItemId
    {
      get
      {
        return _itemId;
      }
      set
      {
        __isset.itemId = true;
        this._itemId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool playerId;
      public bool itemId;
    }

    public DropItem_args() {
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
              PlayerId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              ItemId = iprot.ReadI32();
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
      TStruct struc = new TStruct("DropItem_args");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.playerId) {
        field.Name = "playerId";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PlayerId);
        oprot.WriteFieldEnd();
      }
      if (__isset.itemId) {
        field.Name = "itemId";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ItemId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DropItem_args(");
      sb.Append("PlayerId: ");
      sb.Append(PlayerId);
      sb.Append(",ItemId: ");
      sb.Append(ItemId);
      sb.Append(")");
      return sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class DropItem_result : TBase
  {
    private DNHActionResult _success;

    public DNHActionResult Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
    }

    public DropItem_result() {
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
          case 0:
            if (field.Type == TType.Struct) {
              Success = new DNHActionResult();
              Success.Read(iprot);
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
      TStruct struc = new TStruct("DropItem_result");
      oprot.WriteStructBegin(struc);
      TField field = new TField();

      if (this.__isset.success) {
        if (Success != null) {
          field.Name = "Success";
          field.Type = TType.Struct;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          Success.Write(oprot);
          oprot.WriteFieldEnd();
        }
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DropItem_result(");
      sb.Append("Success: ");
      sb.Append(Success== null ? "<null>" : Success.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
