﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 71, 73, 75, 77, 79, 81, 83, 85, 87, 89, 91, 93, 95, 97, 99, 101, 103, 105, 107, 109, 111, 113, 115, 117, 119, 121, 123, 125, 127, 129, 131, 133, 135, 137, 139, 141, 143, 145, 147, 149, 151, 153, 155, 157, 159, 161, 163, 165, 167, 169, 171, 173, 175, 177, 179, 181, 183, 185, 187, 189, 191, 193, 195, 197, 199, 201, 203, 205, 207, 209, 211, 213, 215, 217, 219, 221, 223, 225, 227, 229, 231, 233, 235, 237, 239, 241, 243, 245, 247, 249, 251, 253, 255, 257, 259, 261, 263, 265, 267, 269, 271, 273, 275, 277, 279, 281, 283, 285, 287, 289, 291, 293, 295, 297, 299, 301, 303, 305, 307, 309, 311, 313, 315, 317, 319, 321, 323, 325, 327, 329, 331, 333, 335, 337, 339, 341, 343, 345, 347, 349, 351, 353, 355, 357, 359, 361, 363, 365, 367, 369, 371, 373, 375, 377, 379, 381, 383, 385, 387, 389, 391, 393, 395, 397, 399, 401, 403, 405, 407, 409, 411, 413, 415, 417, 419, 421, 423, 425, 427, 429, 431, 433, 435, 437, 439, 441, 443, 445, 447, 449, 451, 453, 455, 457, 459, 461, 463, 465, 467, 469, 471, 473, 475, 477, 479, 481, 483, 485, 487, 489, 491, 493, 495, 497, 499, 501, 503, 505, 507, 509, 511, 513, 515, 517, 519, 521, 523, 525, 527, 529, 531, 533, 535, 537, 539, 541, 543, 545, 547, 549, 551, 553, 555, 557, 559, 561, 563, 565, 567, 569, 571, 573, 575, 577, 579, 581, 583, 585, 587, 589, 591, 593, 595, 597, 599, 601, 603, 605, 607, 609, 611, 613, 615, 617, 619, 621, 623, 625, 627, 629, 631, 633, 635, 637, 639, 641, 643, 645, 647, 649, 651, 653, 655, 657, 659, 661, 663, 665, 667, 669, 671, 673, 675, 677, 679, 681, 683, 685, 687, 689, 691, 693, 695, 697, 699, 701, 703, 705, 707, 709, 711, 713, 715, 717, 719, 721, 723, 725, 727, 729, 731, 733, 735, 737, 739, 741, 743, 745, 747, 749, 751, 753, 755, 757, 759, 761, 763, 765, 767, 769, 771, 773, 775, 777, 779, 781, 783, 785, 787, 789, 791, 793, 795, 797, 799, 801, 803, 805, 807, 809, 811, 813, 815, 817, 819, 821, 823, 825, 827, 829, 831, 833, 835, 837, 839, 841, 843, 845, 847, 849, 851, 853, 855, 857, 859, 861, 863, 865, 867, 869, 871, 873, 875, 877, 879, 881, 883, 885, 887, 889, 891, 893, 895, 897, 899, 901, 903, 905, 907, 909, 911, 913, 915, 917, 919, 921, 923, 925, 927, 929, 931, 933, 935, 937, 939, 941, 943, 945, 947, 949, 951, 953, 955, 957, 959, 961, 963, 965, 967, 969, 971, 973, 975, 977, 979, 981, 983, 985, 987, 989, 991, 993, 995, 997, 999, 1001, 1003, 1005, 1007, 1009, 1011, 1013, 1015, 1017, 1019, 1021, 1023, 1025, 1027, 1029, 1031, 1033, 1035, 1037, 1039, 1041, 1043, 1045, 1047, 1049, 1051, 1053, 1055, 1057, 1059, 1061, 1063, 1065, 1067, 1069, 1071, 1073, 1075, 1077, 1079, 1081, 1083, 1085, 1087, 1089, 1091, 1093, 1095, 1097, 1099, 1101, 1103, 1105 };

Search.Linear(arr, 1053);
Search.Linear(arr, 1052);
Console.WriteLine("################");

int[] arr2 = new int[]{ 1,3,5,7,9 };
Search.Binary(arr2, 1);
Console.WriteLine("################");
Search.Binary(arr2, 3);
Console.WriteLine("################");
Search.Binary(arr2, 5);
Console.WriteLine("################");
Search.Binary(arr2, 7);
Console.WriteLine("################");
Search.Binary(arr2, 9);
Console.WriteLine("################");
Search.Binary(arr2, 1);
Console.WriteLine("################");
Search.Binary(arr2, 2);
Console.WriteLine("################");
Search.Binary(arr, 1053);
Search.Binary(arr, 1052);

//----------------------
public static class Search
{
    public static void Binary(int[] arr, int itemToFind)
    {
        
        int lower_idx = 0;
        int upper_idx = arr.Length - 1;
        int middle_idx = 0;
        int count = 0;

        while (true) 
        {
            //suppose we have lo(4) + up(11), then -> ((11-4) + 1) / 2 = (7 + 1) / 2 = 8 / 2 = 4
            // 4 by itself only tells us how many steps we need to move. Now we need to add the index of the
            // lower index in order to make any sense (4) + lo(4) = 8
            middle_idx = ((upper_idx - lower_idx + 1) / 2)+lower_idx;
            int middle_val = arr[middle_idx];

            if (middle_val == itemToFind)
            {
                Console.WriteLine($"Found! Arr[{middle_idx}] = {itemToFind}");
                Console.WriteLine($"    Steps taken:{count}");

                return;
            }
            else if (lower_idx == upper_idx) 
            {
                Console.WriteLine("Item is not present in the array (lower_idx == upper_idx)");
                break;
            }
            else if (itemToFind < middle_val)
            {
                upper_idx = middle_idx - 1;
            }
            else // itemToFind > middle_val
            {
                lower_idx = middle_idx + 1;
            }

            //---------------

            count++; //let's try to prevent an infinite loop;
            if (count == arr.Length)
            {
                Console.WriteLine("Safeguard condition, preventing infinite loop");
                break;
            }


        }

        Console.WriteLine($"Not Found! {itemToFind}");
        Console.WriteLine($"    Steps taken:{count}");
        return;

    }


    public static void Linear(int[] arr , int itemToFind)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            int item = arr[i];
            if (item == itemToFind) 
            { 
                Console.WriteLine($"Found! Arr[{i}] = {item}");
                Console.WriteLine($"    Steps taken:{i}");

                return;
            }
        }

        Console.WriteLine($"Not Found! {itemToFind}");
        Console.WriteLine($"    Steps taken:{arr.Length}");

    }



}