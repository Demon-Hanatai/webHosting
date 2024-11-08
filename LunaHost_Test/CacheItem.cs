﻿using LunaHost_Test;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public  unsafe struct CacheItem<T>:ICacheable where T : ICacheable
{
    public  int TSO;
    public  T* TValue;
    public int CacheCode { get; set; }
    public bool IsNotNullOrDefault() => !IsNull();
    public bool IsNull()
    {
       if((nint)TValue==0)
            return true;
        if (CacheCode == 0) return true;
        return false;
    }
    public bool SubTSO(int index)
    {
        TSO -= index;
        return true;
    }
    public bool CacheEquals(int _CacheCode)
     =>this.CacheCode == _CacheCode;
    public bool IsExpired()
       => this.TSO<=0;
    public override int GetHashCode()
    {
        return (this as ICacheable).GetCacheCode(); 
    }

}

