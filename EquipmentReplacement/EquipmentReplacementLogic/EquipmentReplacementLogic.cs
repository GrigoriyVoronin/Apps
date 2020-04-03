using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentReplacementLogic
{
    public class EquipmentReplacementLogic
    {
            public static (int,List<int>) Run(int[] revenueFromEquipment,int[] equipmentMaintenanceCost,
                int[] sellingPrice, int periodDuration,int priceNewEquipment,int initialAge)
        {
                var maximumRevenueTable = new int[periodDuration - 1, periodDuration];
                var equipmentReplacementTimetable = new bool[periodDuration - 1, periodDuration];
                var revenueFromEquipmentInFirstYear = revenueFromEquipment[0] - equipmentMaintenanceCost[0] - priceNewEquipment;
                DefineReplacementTimetable(periodDuration - 2, revenueFromEquipment, equipmentMaintenanceCost, sellingPrice, maximumRevenueTable,
                    equipmentReplacementTimetable, revenueFromEquipmentInFirstYear);
                return CalculateResult(maximumRevenueTable, equipmentReplacementTimetable, initialAge);
            }

            private static (int,List<int>) CalculateResult(int[,] maximumRevenueTable, bool[,] equipmentReplacementSchedule, int equipmentAge)
            {
                var maxProfit = maximumRevenueTable[0, equipmentAge];
                var yearsWhenChange = new List<int>();
                for (int year = 1; year < maximumRevenueTable.GetLength(1); year++)
                {
                    if (equipmentReplacementSchedule[year - 1, equipmentAge])
                    {
                        yearsWhenChange.Add(year);
                        equipmentAge = 1;
                    }
                    else
                    {
                        equipmentAge++;
                    }
                }

                return (maxProfit, yearsWhenChange);
            }

            private static void DefineReplacementTimetable(int currentYear, int[] revenueFromEquipment, int[] equipmentMaintenanceCost,
                int[] sellingPrice, int[,] maximumRevenueTable, bool[,] equipmentReplacementTimetable, int revenueFromEquipmentInFirstYear)
            {
                if (currentYear == -1)
                    return;
                if (currentYear + 2 == revenueFromEquipment.Length)
                    CalculateRevenueFirst(currentYear, revenueFromEquipment.Length, revenueFromEquipment,
                        equipmentMaintenanceCost, sellingPrice, equipmentReplacementTimetable, maximumRevenueTable,
                        revenueFromEquipmentInFirstYear);
                else
                    CalculateRevenueElse(currentYear, revenueFromEquipment.Length, revenueFromEquipment,
                        equipmentMaintenanceCost, sellingPrice, equipmentReplacementTimetable, maximumRevenueTable,
                        revenueFromEquipmentInFirstYear);
                currentYear--;
                DefineReplacementTimetable(currentYear, revenueFromEquipment, equipmentMaintenanceCost, sellingPrice,
                    maximumRevenueTable, equipmentReplacementTimetable, revenueFromEquipmentInFirstYear);
            }

            private static void CalculateRevenueElse(int currentYear, int periodDuration, int[] revenueFromEquipment,
                int[] equipmentMaintenanceCost, int[] sellingPrice, bool[,] equipmentReplacementTimetable,
                int[,] maximumRevenueTable, int revenueFromEquipmentInFirstYear)
            {

                for (int yearOfUsage = 0; yearOfUsage < periodDuration - 1; yearOfUsage++)
                {
                    var revenueWithSave = revenueFromEquipment[yearOfUsage] - equipmentMaintenanceCost[yearOfUsage] +
                                          maximumRevenueTable[currentYear + 1, yearOfUsage + 1];
                    var revenueWithChange = revenueFromEquipmentInFirstYear + sellingPrice[yearOfUsage] +
                                            maximumRevenueTable[currentYear + 1, 1];
                    if (revenueWithSave >= revenueWithChange)
                    {
                        maximumRevenueTable[currentYear, yearOfUsage] = revenueWithSave;
                    }
                    else
                    {
                        maximumRevenueTable[currentYear, yearOfUsage] = revenueWithChange;
                        equipmentReplacementTimetable[currentYear, yearOfUsage] = true;
                    }
                }

                maximumRevenueTable[currentYear, periodDuration - 1] = maximumRevenueTable[currentYear, periodDuration - 2];
                equipmentReplacementTimetable[currentYear, periodDuration - 1] = true;
            }

            private static void CalculateRevenueFirst(int currentYear, int periodDuration, int[] revenueFromEquipment,
                int[] equipmentMaintenanceCost, int[] sellingPrice, bool[,] equipmentReplacementTimetable,
                int[,] maximumRevenueTable, int revenueFromEquipmentInFirstYear)
            {
                for (int yearOfUsage = 0; yearOfUsage < periodDuration; yearOfUsage++)
                {
                    var revenueWithSave = revenueFromEquipment[yearOfUsage] - equipmentMaintenanceCost[yearOfUsage];
                    var revenueWithChange = revenueFromEquipmentInFirstYear + sellingPrice[yearOfUsage];
                    if (revenueWithSave >= revenueWithChange)
                    {
                        maximumRevenueTable[currentYear, yearOfUsage] = revenueWithSave;
                    }
                    else
                    {
                        maximumRevenueTable[currentYear, yearOfUsage] = revenueWithChange;
                        equipmentReplacementTimetable[currentYear, yearOfUsage] = true;
                    }
                }
            }
    }
    }
