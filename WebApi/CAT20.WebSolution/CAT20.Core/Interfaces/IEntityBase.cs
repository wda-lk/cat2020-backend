#region © 2018 Copyright Pahansoft (Pvt) Ltd
//
// All rights are reserved. Reproduction or transmission in
// whole or in part, in any form or by any means, electronic,
// mechanical or otherwise, is prohibited without the prior
// written consent of the copyright owner.
//
// Filename     : IEntityBase.cs
// Created By   : Lakshitha Wickramarachchi
// Date         : 2018-Jan-12, Fri
// Description  : Base Interface for All
//
// Modified By  : 
// Date         : 
// Purpose      : 
//
#endregion

using System;

namespace CAT20.Core.Models.Interfaces
{
    public interface IEntityBase
    {
        int ID { get; set; }
        //string User { get; set; }
        //byte[] TimeStamp { get; set; }
        //State State { get; set; }
        //DateTime? DateCreated { get; set; }
        //DateTime? DateModified { get; set; }
        //string AuditReference { get; set; }
    }

    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
