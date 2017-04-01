﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class DirectoryOfEquipment
    {
        private static DirectoryOfEquipment instance = new DirectoryOfEquipment();

        public List<Equipment> equipmentList { get; set; }

        // Constructor
        private DirectoryOfEquipment()
        {
            equipmentList = new List<Equipment>();
        }

        // Get instance
        public static DirectoryOfEquipment getInstance()
        {
            return instance;
        }

        // Method to make a new time slot
        public Equipment makeNewEquipment(int equipmentID, int reservationID, string equipmentName)
        {
            Equipment equipment = new Equipment(equipmentID, reservationID, equipmentName);
            if (!equipmentList.Contains(equipment))
                equipmentList.Add(equipment);
            return equipment;
        }


        //need to make sure equipment is not used at same time
        //todo: make it make sense with the EquipmentMapper

        public void getEquipment(DateTime date, int firstHour, int lastHour, List<String> equipmentNameList)
        {
            List<Equipment> equipmentList_temp = equipmentList;
            List<int> equipmentIDList=null;

            //Go through whole equipment list
            foreach(Equipment e_temp in equipmentList_temp)
            {

                //go through name list
                foreach (String name in equipmentNameList)
                {
                    if (e_temp.equipmentName == name)
                    {
                        equipmentIDList.Add(e_temp.equipmentID);
                        equipmentList_temp.Remove(e_temp);

                        //Break because if u find first one
                        break;
                    }
                }
            }
        }

        public Equipment modifyEquipment(int equipmentID, int resID, Queue<int> wlist)
        {
            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentID == equipmentID)
                {
                    equipmentList[i].reservationID = resID;
                    equipmentList[i].equipmentID = equipmentID;
                    equipmentList[i].equipmentWaitList = wlist;
                    return equipmentList[i];
                }
            }
            return null;
        }



    }
}
