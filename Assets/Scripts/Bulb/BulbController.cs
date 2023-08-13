using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbController : MonoBehaviour
{
    [SerializeField] List<GameObject> field_effects;
    [SerializeField] List<GameObject> player_effects;
    [SerializeField] List<GameObject> labels;
    private Dictionary<int, BulbColor> dice = new Dictionary<int, BulbColor>();



    public BulbColor getColor(int color)
    {
        return dice[color];
    }

    public GameObject getPlantSpew(int color)
    {
        return field_effects[color];
    }

    public GameObject getPlayerSpew(int color)
    {
        return player_effects[color];
    }

    void Awake()
    {
        //INITIATE BULB
        BulbColor brown = new BulbColor(0);
        BulbColor red = new BulbColor(1);
        BulbColor yellow = new BulbColor(2);
        BulbColor blue = new BulbColor(3);
        BulbColor green = new BulbColor(4);
        BulbColor purple = new BulbColor(5);
        BulbColor orange = new BulbColor(6);
        BulbColor scarlet = new BulbColor(7);
        BulbColor magenta = new BulbColor(8);
        BulbColor pink = new BulbColor(9);
        BulbColor marigold = new BulbColor(10);
        BulbColor meadow = new BulbColor(11);
        BulbColor sun = new BulbColor(12);
        BulbColor puce = new BulbColor(13);
        BulbColor teal = new BulbColor(14);
        BulbColor mystic = new BulbColor(15);
        BulbColor sky = new BulbColor(16);
        BulbColor eidelwood = new(17);
        BulbColor indigo = new BulbColor(18);
        BulbColor shell = new BulbColor(19);
        BulbColor creamsicle = new BulbColor(20);
        BulbColor cocktail = new BulbColor(21);
        BulbColor marsh = new BulbColor(22);
        BulbColor bouquet = new BulbColor(23);
        BulbColor valentine = new BulbColor(24);
        BulbColor cottoncandy = new BulbColor(25);
        BulbColor thistle = new BulbColor(26);
        BulbColor spooky = new BulbColor(27);
        BulbColor sorbet = new BulbColor(28);
        BulbColor summer = new BulbColor(29);
        BulbColor jade = new BulbColor(30);
        BulbColor beach = new BulbColor(31);
        BulbColor periwinkle = new BulbColor(32);
        BulbColor hurricane = new BulbColor(33);
        BulbColor dawn = new BulbColor(34);
        BulbColor cavalier = new BulbColor(35);
        BulbColor mint = new BulbColor(36);
        BulbColor omni = new BulbColor(37);
        BulbColor white = new BulbColor(38);
        BulbColor black = new BulbColor(39);

        //COMBINATION INITIATIONS
        red.AddCombination(orange, scarlet);
        red.AddCombination(yellow, orange);
        red.AddCombination(blue, purple);
        red.AddCombination(purple, magenta);
        red.AddCombination(white, pink);
        orange.AddCombination(red, scarlet);
        orange.AddCombination(yellow, marigold);
        orange.AddCombination(green, puce);
        orange.AddCombination(purple, eidelwood);
        orange.AddCombination(white, creamsicle);
        yellow.AddCombination(red, orange);
        yellow.AddCombination(orange, marigold);
        yellow.AddCombination(green, meadow);
        yellow.AddCombination(blue, green);
        yellow.AddCombination(white, sun);
        green.AddCombination(orange, puce);
        green.AddCombination(yellow, meadow);
        green.AddCombination(blue, teal);
        green.AddCombination(purple, mystic);
        green.AddCombination(white, mint);
        blue.AddCombination(red, purple);
        blue.AddCombination(yellow, green);
        blue.AddCombination(green, teal);
        blue.AddCombination(purple, indigo);
        blue.AddCombination(white, sky);
        purple.AddCombination(red, magenta);
        purple.AddCombination(orange, eidelwood);
        purple.AddCombination(green, mystic);
        purple.AddCombination(blue, indigo);
        purple.AddCombination(white, shell);
        purple.AddCombination(purple, white);
        scarlet.AddCombination(mint, cocktail);
        meadow.AddCombination(puce, marsh);
        marigold.AddCombination(eidelwood, bouquet);
        magenta.AddCombination(red, valentine);
        pink.AddCombination(blue, cottoncandy);
        puce.AddCombination(green, thistle);
        eidelwood.AddCombination(mystic, spooky);
        creamsicle.AddCombination(pink, sorbet);
        sun.AddCombination(meadow, summer);
        mint.AddCombination(indigo, jade);
        sky.AddCombination(sun, beach);
        shell.AddCombination(sky, periwinkle);
        teal.AddCombination(shell, hurricane);
        mystic.AddCombination(scarlet, dawn);
        indigo.AddCombination(orange, cavalier);
        brown.AddCombination(white, omni);


        dice.Add(0, brown); //brown
        dice.Add(1, red); //red
        dice.Add(2, yellow); //yellow
        dice.Add(3, blue); //blue
        dice.Add(4, green); //green 
        dice.Add(5,purple); //purple
        dice.Add(6, orange); //orange
        dice.Add(7, scarlet); //scarlet
        dice.Add(8, magenta); //magenta
        dice.Add(9, pink); //pink
        dice.Add(10, marigold); //marigold
        dice.Add(11, meadow); //meadow
        dice.Add(12, sun); //sun
        dice.Add(13, puce); //puce
        dice.Add(14, teal); //teal
        dice.Add(15, mystic); //mystic
        dice.Add(16, sky); //sky
        dice.Add(17, eidelwood); //eidelwood
        dice.Add(18, indigo); //indigo
        dice.Add(19, shell); //shell
        dice.Add(20, creamsicle); //creamsicle
        dice.Add(21, cocktail); //cocktail
        dice.Add(22, marsh); //marsh
        dice.Add(23, bouquet); //bouquet
        dice.Add(24, valentine); //valentine
        dice.Add(25, cottoncandy); //cottoncandy
        dice.Add(26, thistle); //thistle
        dice.Add(27, spooky); //spooky
        dice.Add(28, sorbet); //sorbet
        dice.Add(29, summer); //summer
        dice.Add(30, jade); //jade
        dice.Add(31, beach); //beach
        dice.Add(32, periwinkle); //periwinkle
        dice.Add(33, hurricane); //hurricane
        dice.Add(34, dawn); //dawn
        dice.Add(35, cavalier); //cavalier
        dice.Add(36, mint); 
        dice.Add(37, omni); //omni
        dice.Add(38, white); //white
        dice.Add(39, black);
    }

    // Start is called before the first frame update
    public BulbColor SetColor(BulbColor a, BulbColor c)
    {
        if(c.Name == 39) //special logic for black
        {
            return dice[39];
        }
        if (a.RunCombination(c) != -1)
        {
            return dice[a.RunCombination(c)];
        }
        else 
        {
            return dice[0];
        }
    }
}
