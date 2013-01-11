using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetDesign.Roulette.Models
{
    public class Slot
    {
        private static Random _random = new Random();
        private bool IsRandom { get; set; }
        public Number[] WinningNumbers { get; set; }
        public int Multiplier { get; set; }

        private Slot(int multiplier)
        {
            Multiplier = multiplier;
            IsRandom = true;
        }

        public Slot(int multiplier, params Number[] winningNumbers)
        {
            Multiplier = multiplier;
            WinningNumbers = winningNumbers;
            IsRandom = false;
        }

        public bool IsWinner(Number hitNumber)
        {
            return (IsRandom)
                ? (Number)_random.Next(1, 39) == hitNumber
                : WinningNumbers.Contains(hitNumber);
        }

        public int GetWinnings(bool isWinner, int betAmount)
        {
            return isWinner
                       ? (Multiplier + 1)*betAmount
                       : 0;
        }

        public static Dictionary<SlotType, Slot> Slots = new Dictionary<SlotType, Slot>
            {
                {SlotType.RandomSingleValue, new Slot(35)},
                {SlotType.Zero, new Slot(35, Number.Zero)},
                {SlotType.DoubleZero, new Slot(35, Number.DoubleZero)},
                {SlotType.One, new Slot(35, Number.One)},
                {SlotType.Two, new Slot(35, Number.Two)},
                {SlotType.Three, new Slot(35, Number.Three)},
                {SlotType.Four, new Slot(35, Number.Four)},
                {SlotType.Five, new Slot(35, Number.Five)},
                {SlotType.Six, new Slot(35, Number.Six)},
                {SlotType.Seven, new Slot(35, Number.Seven)},
                {SlotType.Eight, new Slot(35, Number.Eight)},
                {SlotType.Nine, new Slot(35, Number.Nine)},
                {SlotType.Ten, new Slot(35, Number.Ten)},
                {SlotType.Eleven, new Slot(35, Number.Eleven)},
                {SlotType.Twelve, new Slot(35, Number.Twelve)},
                {SlotType.Thirteen, new Slot(35, Number.Thirteen)},
                {SlotType.Fourteen, new Slot(35, Number.Fourteen)},
                {SlotType.Fifteen, new Slot(35, Number.Fifteen)},
                {SlotType.Sixteen, new Slot(35, Number.Sixteen)},
                {SlotType.Seventeen, new Slot(35, Number.Seventeen)},
                {SlotType.Eighteen, new Slot(35, Number.Eighteen)},
                {SlotType.Ninteen, new Slot(35, Number.Ninteen)},
                {SlotType.Twenty, new Slot(35, Number.Twenty)},
                {SlotType.TwentyOne, new Slot(35, Number.TwentyOne)},
                {SlotType.TwentyTwo, new Slot(35, Number.TwentyTwo)},
                {SlotType.TwentyThree, new Slot(35, Number.TwentyThree)},
                {SlotType.TwentyFour, new Slot(35, Number.TwentyFour)},
                {SlotType.TwentyFive, new Slot(35, Number.TwentyFive)},
                {SlotType.TwentySix, new Slot(35, Number.TwentySix)},
                {SlotType.TwentySeven, new Slot(35, Number.TwentySeven)},
                {SlotType.TwentyEight, new Slot(35, Number.TwentyEight)},
                {SlotType.TwentyNine, new Slot(35, Number.TwentyNine)},
                {SlotType.Thirty, new Slot(35, Number.Thirty)},
                {SlotType.ThirtyOne, new Slot(35, Number.ThirtyOne)},
                {SlotType.ThirtyTwo, new Slot(35, Number.ThirtyTwo)},
                {SlotType.ThirtyThree, new Slot(35, Number.ThirtyThree)},
                {SlotType.ThirtyFour, new Slot(35, Number.ThirtyFour)},
                {SlotType.ThirtyFive, new Slot(35, Number.ThirtyFive)},
                {SlotType.ThirtySix, new Slot(35, Number.ThirtySix)},
                {SlotType.Split_Zero_DoubleZero, new Slot(17, Number.Zero, Number.DoubleZero)},
                {SlotType.Split_One_Two, new Slot(17, Number.One, Number.Two)},
                {SlotType.Split_Two_Three, new Slot(17, Number.Two, Number.Three)},
                {SlotType.Split_One_Four, new Slot(17, Number.One, Number.Four)},
                {SlotType.Split_Two_Five, new Slot(17, Number.Two, Number.Five)},
                {SlotType.Split_Three_Six, new Slot(17, Number.Three, Number.Six)},
                {SlotType.Split_Four_Five, new Slot(17, Number.Four, Number.Five)},
                {SlotType.Split_Five_Six, new Slot(17, Number.Five, Number.Six)},
                {SlotType.Split_Four_Seven, new Slot(17, Number.Four, Number.Seven)},
                {SlotType.Split_Five_Eight, new Slot(17, Number.Five, Number.Eight)},
                {SlotType.Split_Six_Nine, new Slot(17, Number.Six, Number.Nine)},
                {SlotType.Split_Seven_Eight, new Slot(17, Number.Seven, Number.Eight)},
                {SlotType.Split_Eight_Nine, new Slot(17, Number.Eight, Number.Nine)},
                {SlotType.Split_Seven_Ten, new Slot(17, Number.Seven, Number.Ten)},
                {SlotType.Split_Eight_Eleven, new Slot(17, Number.Eight, Number.Eleven)},
                {SlotType.Split_Nine_Twelve, new Slot(17, Number.Nine, Number.Twelve)},
                {SlotType.Split_Ten_Eleven, new Slot(17, Number.Ten, Number.Eleven)},
                {SlotType.Split_Eleven_Twelve, new Slot(17, Number.Eleven, Number.Twelve)},
                {SlotType.Split_Ten_Thirteen, new Slot(17, Number.Ten, Number.Thirteen)},
                {SlotType.Split_Eleven_Fourteen, new Slot(17, Number.Eleven, Number.Fourteen)},
                {SlotType.Split_Twelve_Fifteen, new Slot(17, Number.Twelve, Number.Fifteen)},
                {SlotType.Split_Thirteen_Fourteen, new Slot(17, Number.Thirteen, Number.Fourteen)},
                {SlotType.Split_Fourteen_Fifteen, new Slot(17, Number.Fourteen, Number.Fifteen)},
                {SlotType.Split_Thirteen_Sixteen, new Slot(17, Number.Thirteen, Number.Sixteen)},
                {SlotType.Split_Fourteen_Seventeen, new Slot(17, Number.Fourteen, Number.Seventeen)},
                {SlotType.Split_Fifteen_Eighteen, new Slot(17, Number.Fifteen, Number.Eighteen)},
                {SlotType.Split_Sixteen_Seventeen, new Slot(17, Number.Sixteen, Number.Seventeen)},
                {SlotType.Split_Seventeen_Eighteen, new Slot(17, Number.Seventeen, Number.Eighteen)},
                {SlotType.Split_Sixteen_Nineteen, new Slot(17, Number.Sixteen, Number.Ninteen)},
                {SlotType.Split_Seventeen_Twenty, new Slot(17, Number.Seventeen, Number.Twenty)},
                {SlotType.Split_Eighteen_TwentyOne, new Slot(17, Number.Eighteen, Number.TwentyOne)},
                {SlotType.Split_Nineteen_Twenty, new Slot(17, Number.Ninteen, Number.Twenty)},
                {SlotType.Split_Twenty_TwentyOne, new Slot(17, Number.Twenty, Number.TwentyOne)},
                {SlotType.Split_Nineteen_TwentyTwo, new Slot(17, Number.Ninteen, Number.TwentyTwo)},
                {SlotType.Split_Twenty_TwentyThree, new Slot(17, Number.Twenty, Number.TwentyThree)},
                {SlotType.Split_TwentyOne_TwentyFour, new Slot(17, Number.TwentyOne, Number.TwentyFour)},
                {SlotType.Split_TwentyTwo_TwentyThree, new Slot(17, Number.TwentyTwo, Number.TwentyThree)},
                {SlotType.Split_TwentyThree_TwentyFour, new Slot(17, Number.TwentyThree, Number.TwentyFour)},
                {SlotType.Split_TwentyTwo_TwentyFive, new Slot(17, Number.TwentyTwo, Number.TwentyFive)},
                {SlotType.Split_TwentyThree_TwentySix, new Slot(17, Number.TwentyThree, Number.TwentySix)},
                {SlotType.Split_TwentyFour_TwentySeven, new Slot(17, Number.TwentyFour, Number.TwentySeven)},
                {SlotType.Split_TwentyFive_TwentySix, new Slot(17, Number.TwentyFive, Number.TwentySix)},
                {SlotType.Split_TwentySix_TwentySeven, new Slot(17, Number.TwentySix, Number.TwentySeven)},
                {SlotType.Split_TwentyFive_TwentyEight, new Slot(17, Number.TwentyFive, Number.TwentyEight)},
                {SlotType.Split_TwentySix_TwentyNine, new Slot(17, Number.TwentySix, Number.TwentyNine)},
                {SlotType.Split_TwentySeven_Thirty, new Slot(17, Number.TwentySeven, Number.Thirty)},
                {SlotType.Split_TwentyEight_TwentyNine, new Slot(17, Number.TwentyEight, Number.TwentyNine)},
                {SlotType.Split_TwentyNine_Thirty, new Slot(17, Number.TwentyNine, Number.Thirty)},
                {SlotType.Split_TwentyEight_ThirtyOne, new Slot(17, Number.TwentyEight, Number.ThirtyOne)},
                {SlotType.Split_TwentyNine_ThirtyTwo, new Slot(17, Number.TwentyNine, Number.ThirtyTwo)},
                {SlotType.Split_Thirty_ThirtyThree, new Slot(17, Number.Thirty, Number.ThirtyThree)},
                {SlotType.Split_ThirtyOne_ThirtyTwo, new Slot(17, Number.ThirtyOne, Number.ThirtyTwo)},
                {SlotType.Split_ThirtyTwo_ThirtyThree, new Slot(17, Number.ThirtyTwo, Number.ThirtyThree)},
                {SlotType.Split_ThirtyOne_ThirtyFour, new Slot(17, Number.ThirtyOne, Number.ThirtyFour)},
                {SlotType.Split_ThirtyTwo_ThirtyFive, new Slot(17, Number.ThirtyTwo, Number.Fifteen)},
                {SlotType.Split_ThirtyThree_ThirtySix, new Slot(17, Number.ThirtyThree, Number.ThirtySix)},
                {SlotType.Split_ThirtyFour_ThirtyFive, new Slot(17, Number.ThirtyFour, Number.Fifteen)},
                {SlotType.Split_ThirtyFive_ThirtySix, new Slot(17, Number.ThirtyFive, Number.ThirtySix)},
                {SlotType.Street_One_Two_Three, new Slot(11, Number.One, Number.Two, Number.Three)},
                {SlotType.Street_Four_Five_Six, new Slot(11, Number.Four, Number.Five, Number.Six)},
                {SlotType.Street_Seven_Eight_Nine, new Slot(11, Number.Seven, Number.Eight, Number.Nine)},
                {SlotType.Street_Ten_Eleven_Twelve, new Slot(11, Number.Ten, Number.Eleven, Number.Twelve)},
                {
                    SlotType.Street_Thirteen_Fourteen_Fifteen,
                    new Slot(11, Number.Thirteen, Number.Fourteen, Number.Fifteen)
                },
                {
                    SlotType.Street_Sixteen_Seventeen_Eighteen,
                    new Slot(11, Number.Sixteen, Number.Seventeen, Number.Eighteen)
                },
                {
                    SlotType.Street_Nineteen_Twenty_TwentyOne,
                    new Slot(11, Number.Ninteen, Number.Twenty, Number.TwentyOne)
                },
                {
                    SlotType.Street_TwentyTwo_TwentyThree_TwentyFour,
                    new Slot(11, Number.TwentyTwo, Number.TwentyThree, Number.TwentyFour)
                },
                {
                    SlotType.Street_TwentyFive_TwentySix_TwentySeven,
                    new Slot(11, Number.TwentyFive, Number.TwentySix, Number.TwentySeven)
                },
                {
                    SlotType.Street_TwentyEight_TwentyNine_Thirty,
                    new Slot(11, Number.TwentyEight, Number.TwentyNine, Number.Thirty)
                },
                {
                    SlotType.Street_ThirtyOne_ThirtyTwo_ThirtyThree,
                    new Slot(11, Number.ThirtyOne, Number.ThirtyTwo, Number.ThirtyThree)
                },
                {
                    SlotType.Street_ThirtyFour_ThirtyFive_ThirtySix,
                    new Slot(11, Number.ThirtyFour, Number.ThirtyFive, Number.ThirtySix)
                },
                {SlotType.Corner_One_Two_Four_Five, new Slot(8, Number.One, Number.Two, Number.Four, Number.Five)},
                {SlotType.Corner_Two_Three_Five_Six, new Slot(8, Number.Two, Number.Three, Number.Five, Number.Six)},
                {
                    SlotType.Corner_Four_Five_Seven_Eight,
                    new Slot(8, Number.Four, Number.Five, Number.Seven, Number.Eight)
                },
                {SlotType.Corner_Five_Six_Eight_Nine, new Slot(8, Number.Five, Number.Six, Number.Eight, Number.Nine)},
                {
                    SlotType.Corner_Seven_Eight_Ten_Eleven,
                    new Slot(8, Number.Seven, Number.Eight, Number.Ten, Number.Eleven)
                },
                {
                    SlotType.Corner_Eight_Nine_Eleven_Twelve,
                    new Slot(8, Number.Eight, Number.Nine, Number.Eleven, Number.Twelve)
                },
                {
                    SlotType.Corner_Ten_Eleven_Thirteen_Fourteen,
                    new Slot(8, Number.Ten, Number.Eleven, Number.Thirteen, Number.Fourteen)
                },
                {
                    SlotType.Corner_Eleven_Twelve_Fourteen_Fifteen,
                    new Slot(8, Number.Eleven, Number.Twelve, Number.Fourteen, Number.Fifteen)
                },
                {
                    SlotType.Corner_Thirteen_Fourteen_Sixteen_Seventeen,
                    new Slot(8, Number.Thirteen, Number.Fourteen, Number.Sixteen, Number.Seventeen)
                },
                {
                    SlotType.Corner_Fourteen_Fifteen_Seventeen_Eighteen,
                    new Slot(8, Number.Fourteen, Number.Fifteen, Number.Seventeen, Number.Eighteen)
                },
                {
                    SlotType.Corner_Sixteen_Seventeen_Ninteen_Twenty,
                    new Slot(8, Number.Sixteen, Number.Seventeen, Number.Ninteen, Number.Twenty)
                },
                {
                    SlotType.Corner_Seventeen_Eighteen_Twenty_TwentyOne,
                    new Slot(8, Number.Seventeen, Number.Eighteen, Number.Twenty, Number.TwentyOne)
                },
                {
                    SlotType.Corner_Ninteen_Twenty_TwentyTwo_TwentyThree,
                    new Slot(8, Number.Ninteen, Number.Twenty, Number.TwentyTwo, Number.TwentyThree)
                },
                {
                    SlotType.Corner_Twenty_TwentyOne_TwentyThree_TwentyFour,
                    new Slot(8, Number.Twenty, Number.TwentyOne, Number.TwentyThree, Number.TwentyFour)
                },
                {
                    SlotType.Corner_TwentyTwo_TwentyThree_TwentyFive_TwentySix,
                    new Slot(8, Number.TwentyTwo, Number.TwentyThree, Number.TwentyFive, Number.TwentySix)
                },
                {
                    SlotType.Corner_TwentyThree_TwentyFour_TwentySix_TwentySeven,
                    new Slot(8, Number.TwentyThree, Number.TwentyFour, Number.TwentySix, Number.TwentySeven)
                },
                {
                    SlotType.Corner_TwentyFive_TwentySix_TwentyEight_TwentyNine,
                    new Slot(8, Number.TwentyFive, Number.TwentySix, Number.TwentyEight, Number.TwentyNine)
                },
                {
                    SlotType.Corner_TwentySix_TwentySeven_TwentyNine_Thirty,
                    new Slot(8, Number.TwentySix, Number.TwentySeven, Number.TwentyNine, Number.Thirty)
                },
                {
                    SlotType.Corner_TwentyEight_TwentyNine_ThirtyOne_ThirtyTwo,
                    new Slot(8, Number.TwentyEight, Number.TwentyNine, Number.ThirtyOne, Number.ThirtyTwo)
                },
                {
                    SlotType.Corner_TwentyNine_Thirty_ThrityTwo_ThirtyThree,
                    new Slot(8, Number.TwentyNine, Number.Thirty, Number.ThirtyTwo, Number.ThirtyThree)
                },
                {
                    SlotType.Corner_ThirtyOne_ThirtyTwo_ThirtyFour_ThirtyFive,
                    new Slot(8, Number.ThirtyOne, Number.ThirtyTwo, Number.ThirtyFour, Number.ThirtyFive)
                },
                {
                    SlotType.Corner_ThirtyTwo_ThirtyThree_ThirtyFive_ThirtySix,
                    new Slot(8, Number.ThirtyTwo, Number.ThirtyThree, Number.ThirtyFive, Number.ThirtySix)
                },
                {
                    SlotType.SixLine_One_Two_Three_Four_Five_Six,
                    new Slot(5, Number.One, Number.Two, Number.Three, Number.Four, Number.Five, Number.Six)
                },
                {
                    SlotType.SixLine_Four_Five_Six_Seven_Eight_Nine,
                    new Slot(5, Number.Four, Number.Five, Number.Six, Number.Seven, Number.Eight, Number.Nine)
                },
                {
                    SlotType.SixLine_Seven_Eight_Nine_Ten_Eleven_Twelve,
                    new Slot(5, Number.Seven, Number.Eight, Number.Nine, Number.Ten, Number.Eleven, Number.Twelve)
                },
                {
                    SlotType.SixLine_Ten_Eleven_Twelve_Thirteen_Fourteen_Fifteen,
                    new Slot(5, Number.Ten, Number.Eleven, Number.Twelve, Number.Thirteen, Number.Fourteen,
                             Number.Fifteen)
                },
                {
                    SlotType.SixLine_Thirteen_Fourteen_Fifteen_Sixteen_Seventeen_Eighteen,
                    new Slot(5, Number.Thirteen, Number.Fourteen, Number.Fifteen, Number.Sixteen, Number.Seventeen,
                             Number.Eighteen)
                },
                {
                    SlotType.SixLine_Sixteen_Seventeen_Eighteen_Ninteen_Twenty_TwentyOne,
                    new Slot(5, Number.Sixteen, Number.Seventeen, Number.Eighteen, Number.Ninteen, Number.Twenty,
                             Number.TwentyOne)
                },
                {
                    SlotType.SixLine_Ninteen_Twenty_TwentyOne_TwentyTwo_TwentyThree_TwentyFour,
                    new Slot(5, Number.Ninteen, Number.Twenty, Number.TwentyOne, Number.TwentyTwo, Number.TwentyThree)
                },
                {
                    SlotType.SixLine_TwentyTwo_TwentyThree_TwentyFour_TwentyFive_TwentySix_TwentySeven,
                    new Slot(5, Number.TwentyTwo, Number.TwentyThree, Number.TwentyFour, Number.TwentyFive,
                             Number.TwentySix, Number.TwentySeven)
                },
                {
                    SlotType.SixLine_TwentyFive_TwentySix_TwentySeven_TwentyEight_TwentyNine_Thirty,
                    new Slot(5, Number.TwentyFive, Number.TwentySix, Number.TwentySeven, Number.TwentyEight,
                             Number.TwentyNine, Number.Thirty)
                },
                {
                    SlotType.SixLine_TwentyEight_TwentyNine_Thirty_ThirtyOne_ThirtyTwo_ThirtyThree,
                    new Slot(5, Number.TwentyEight, Number.TwentyNine, Number.Thirty, Number.ThirtyOne, Number.ThirtyTwo,
                             Number.ThirtyThree)
                },
                {
                    SlotType.SixLine_ThirtyOne_ThirtyTwo_ThirtyThree_ThirtyFour_ThirtyFive_ThirtySix,
                    new Slot(5, Number.ThirtyOne, Number.ThirtyTwo, Number.ThirtyThree, Number.ThirtyFour,
                             Number.ThirtyFive, Number.ThirtySix)
                },
                {
                    SlotType.FirstColumn,
                    new Slot(2, Number.One, Number.Four, Number.Seven, Number.Ten, Number.Thirteen, Number.Sixteen,
                             Number.Ninteen, Number.TwentyTwo, Number.TwentyFive, Number.TwentyEight, Number.ThirtyOne,
                             Number.ThirtyFour)
                },
                {
                    SlotType.SecondColumn,
                    new Slot(2, Number.Two, Number.Five, Number.Eight, Number.Eleven, Number.Fourteen, Number.Seventeen,
                             Number.Twenty, Number.TwentyThree, Number.TwentySix, Number.TwentyNine, Number.ThirtyTwo,
                             Number.ThirtyFive)
                },
                {
                    SlotType.ThirdColumn,
                    new Slot(2, Number.Three, Number.Six, Number.Nine, Number.Twelve, Number.Fifteen, Number.Eighteen,
                             Number.TwentyOne, Number.TwentyFour, Number.TwentySeven, Number.Thirty, Number.ThirtyThree,
                             Number.ThirtySix)
                },
                {
                    SlotType.FirstDozen,
                    new Slot(2, Number.One, Number.Two, Number.Three, Number.Four, Number.Five, Number.Six, Number.Seven,
                             Number.Eight, Number.Nine, Number.Ten, Number.Eleven, Number.Twelve)
                },
                {
                    SlotType.SecondDozen,
                    new Slot(2, Number.Thirteen, Number.Fourteen, Number.Fifteen, Number.Sixteen, Number.Seventeen,
                             Number.Eighteen, Number.Ninteen, Number.Twenty, Number.TwentyOne, Number.TwentyTwo,
                             Number.TwentyThree, Number.TwentyFour)
                },
                {
                    SlotType.ThirdDozen,
                    new Slot(2, Number.TwentyFive, Number.TwentySix, Number.TwentySeven, Number.TwentyEight,
                             Number.TwentyNine, Number.Thirty, Number.ThirtyOne, Number.ThirtyTwo, Number.ThirtyThree,
                             Number.ThirtyFour, Number.ThirtyFive, Number.ThirtySix)
                },
                {
                    SlotType.Odd,
                    new Slot(1, Number.One, Number.Three, Number.Five, Number.Seven, Number.Nine, Number.Eleven,
                             Number.Thirteen, Number.Fifteen, Number.Seventeen, Number.Ninteen, Number.TwentyOne,
                             Number.TwentyThree, Number.TwentyFive, Number.TwentySeven, Number.TwentyNine,
                             Number.ThirtyOne, Number.ThirtyThree, Number.ThirtyFive)
                },
                {
                    SlotType.Even,
                    new Slot(1, Number.Two, Number.Four, Number.Six, Number.Eight, Number.Ten, Number.Twelve,
                             Number.Fourteen, Number.Sixteen, Number.Eighteen, Number.Twenty, Number.TwentyTwo,
                             Number.TwentyFour, Number.TwentySix, Number.TwentyEight, Number.Thirty, Number.ThirtyTwo,
                             Number.ThirtyFour, Number.ThirtySix)
                },
                {
                    SlotType.Red,
                    new Slot(1, Number.Two, Number.Four, Number.Six, Number.Eight, Number.Ten, Number.Eleven,
                             Number.Thirteen, Number.Fifteen, Number.Seventeen, Number.Twenty, Number.TwentyTwo,
                             Number.TwentyFour, Number.TwentySix, Number.TwentyEight, Number.TwentyNine,
                             Number.ThirtyOne, Number.ThirtyThree, Number.ThirtyFive)
                },
                {
                    SlotType.Black,
                    new Slot(1, Number.One, Number.Three, Number.Five, Number.Seven, Number.Nine, Number.Twelve,
                             Number.Fourteen, Number.Sixteen, Number.Eighteen, Number.Ninteen, Number.TwentyOne,
                             Number.TwentyThree, Number.TwentyFive, Number.TwentySeven, Number.Thirty, Number.ThirtyTwo,
                             Number.ThirtyFour, Number.ThirtySix)
                }
            };
    }
}