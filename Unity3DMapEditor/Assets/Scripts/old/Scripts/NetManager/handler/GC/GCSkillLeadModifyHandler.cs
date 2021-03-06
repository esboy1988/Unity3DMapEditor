﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Network.Packets;
namespace Network.Handlers
{
    public class GCCharSkillLeadModifyHandler : HandlerBase
    {
        public override NET_RESULT_DEFINE.PACKET_EXE Execute(PacketBase pPacket, ref Peer pPlayer)
        {
            GCCharSkillLeadModify Packet = (GCCharSkillLeadModify)pPacket;

            if (GameProcedure.GetActiveProcedure() == GameProcedure.s_ProcMain)
			{
                CObject pObj = CObjectManager.Instance.FindServerObject(Packet.ObjectID);

				
				if ( pObj != null )
				{
					SCommand_Object cmdTemp = new SCommand_Object();
					cmdTemp.m_wID			= (int)OBJECTCOMMANDDEF.OC_SKILL_LEAD_MODIFY;
					
					cmdTemp.SetValue<float>(0,(float)Packet.SubTime/1000.0f);
					pObj.PushCommand(cmdTemp );
			
					//pObj->PushDebugString("GCCharSkill_Lead_Modify");
					pObj.SetMsgTime(GameProcedure.s_pTimeSystem.GetTimeNow());
				}
				LogManager.Log("RECV GCCharSkillLeadModify");
			}
            return NET_RESULT_DEFINE.PACKET_EXE.PACKET_EXE_CONTINUE;
        }

        public override int GetPacketID()
        {
            return (int)PACKET_DEFINE.PACKET_GC_CHARSKILL_LEAD_MODIFY;
        }
    }
};
