﻿using Lib_K_Relay.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_Relay
{
    partial class FrmMain
    {
        private void InitPackets()
        {
            PacketSerializer.SerializeTiles();
            PacketSerializer.SerializeItems();
            PacketSerializer.SerializeObjects();
            PacketSerializer.SerializePacketTypes();
            PacketSerializer.SerializePacketsIds();

            foreach (PacketType type in Enum.GetValues(typeof(PacketType)).Cast<PacketType>())
                treePackets.Nodes.Insert(0, type.ToString());

            treePackets.Sort();
        }

        private void treePackets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Type type = PacketSerializer.GetPacketType(
                (PacketType)Enum.Parse(typeof(PacketType), e.Node.Text));
            tbxPacketInfo.Text = (Activator.CreateInstance(type) as Packet).ToStructure();
        }

        private void btnOpenPacketsFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\XML\");
        }
    }
}
