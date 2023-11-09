using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PuzzleManager 
{
    private static bool[] isAPuzzleToSolveHereLevel1 = new bool[]
    {
        false, // Position 1
        false, // Position 2
        false, // Position 3
        false, // Position 4
        true // Position 5 - Bottle Puzzle
    };
    
    private static bool[] isAPuzzleToSolveHereLevel2 = new bool[]
    {
        false, // Position 1
        false, // Position 2
        false, // Position 3
        false, // Position 4
        false, // Position 5
        false, // Position 6
        false, // Position 7
        false, // Position 8
        false, // Position 9
        false, // Position 10
        false, // Position 11
        false, // Position 12
        false, // Position 13
        false, // Position 14
        false, // Position 15
        false, // Position 16
        false, // Position 17
        false, // Position 18
        false, // Position 19
        false, // Position 20
        false // Position 21
    };
    
    private static bool[] isAPuzzleToSolveHereLevel3 = new bool[]
    {
        false, // Position 1
        false, // Position 2
        false, // Position 3
        false, // Position 4
        false, // Position 5
        false, // Position 6
        true, // Position 7 - Fruit Puzzle
        false, // Position 8
        false, // Position 9
        false, // Position 10
        false, // Position 11
        false, // Position 12
        false, // Position 13
        false, // Position 14
        false, // Position 15
        false, // Position 16
        false, // Position 17
        false // Position 18
    };

    public static void SetPuzzleSolved(Transform rootTransformSphere)
    {
            // Names look like: Room2FrontSphere01
            string name = rootTransformSphere.gameObject.name;
            string nameWithRoomRemoved = name.Substring(5);
            int room = int.Parse(name.Substring(4, 1));
            int positionStartIndex = 0;
            int positionLength = 1;
    
            for (int i = 0; i < nameWithRoomRemoved.Length; i++)
            {
                if (!char.IsDigit(nameWithRoomRemoved, i)) continue;
                positionStartIndex = i;
                if (char.IsDigit(nameWithRoomRemoved, i + 1)) positionLength = 2;
                break;
            }
    
            int position = int.Parse(nameWithRoomRemoved.Substring(positionStartIndex, positionLength));
            
            switch (room)
            {
                case 1:
                    isAPuzzleToSolveHereLevel1[position - 1] = false;
                    break;
                case 2:
                    isAPuzzleToSolveHereLevel2[position - 1] = false;
                    break;
                case 3:
                    isAPuzzleToSolveHereLevel3[position - 1] = false;
                    break;
            }
    }
    
    public static bool IsPuzzleToSolve(Transform rootTransformSphere)
    {
        // Names look like: Room2FrontSphere01
        string name = rootTransformSphere.gameObject.name;
        string nameWithRoomRemoved = name.Substring(5);
        int room = int.Parse(name.Substring(4, 1));
        int positionStartIndex = 0;
        int positionLength = 1;

        for (int i = 0; i < nameWithRoomRemoved.Length; i++)
        {
            if (!char.IsDigit(nameWithRoomRemoved, i)) continue;
            positionStartIndex = i;
            if (char.IsDigit(nameWithRoomRemoved, i + 1)) positionLength = 2;
            break;
        }

        int position = int.Parse(nameWithRoomRemoved.Substring(positionStartIndex, positionLength));
        
        switch (room)
        {
            case 1:
                return isAPuzzleToSolveHereLevel1[position - 1];
            case 2:
                return isAPuzzleToSolveHereLevel2[position - 1];
            case 3:
                return isAPuzzleToSolveHereLevel3[position - 1];
            default:
                return false;
        }
    }
}
