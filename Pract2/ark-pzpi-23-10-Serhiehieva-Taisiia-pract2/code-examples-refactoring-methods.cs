//=====В.1 Move Field до рефаторингу=====

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int HP = 100;
    public int EP = 50;
    public List<Skill> skills;
    
    // Поточний активний гріх босса (не логічно, бо це дані ворога)
    public string currentSin;

    public void Attack(EnemyBoss enemy)
    {
        int damage = 10;
        enemy.HP -= damage;
        Debug.Log($"{name} атакує {enemy.name} і завдає {damage} урону. Активний гріх: {currentSin}");
    }
}

public class EnemyBoss : MonoBehaviour
{
    public string name;
    public int HP = 150;
    public List<Skill> skills;
}

//=====В.2 Move Field після рефакторингу=====

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int HP = 100;
    public int EP = 50;
    public List<Skill> skills;

    public void Attack(EnemyBoss enemy)
    {
        int damage = 10;
        enemy.HP -= damage;
        Debug.Log($"{name} атакує {enemy.name} і завдає {damage} урону. Активний гріх ворога: {enemy.currentSin}");
    }
}

public class EnemyBoss : MonoBehaviour
{
    public string name;
    public int HP = 150;
    public List<Skill> skills;

    // Тепер currentSin належить босу, що логічніше
    public string currentSin;

    public void UseSinEffect(Player player)
    {
        if (currentSin == "Wrath")
        {
            int damage = 15;
            player.HP -= damage;
            Debug.Log($"{name} використовує Wrath на {player.name} і завдає {damage} урону!");
        }
        else if (currentSin == "Sloth")
        {
            player.EP -= 5;
            Debug.Log($"{name} накладає Sloth на {player.name}, зменшуючи EP на 5!");
        }
    }
}



//=====В.3 Add Parameter до рефакторингу=====

using System;
using System.Collections.Generic;

class Player
{
    public string name;
    public int HP;
    public int PsP;
    public int EP;
    public int PDMG;
    public int MDMG;
    public int actionLevel;
    public List<Skill> skills;
    public bool isPanicking;
    public bool canAct;

    public void Attack(EnemyBoss enemy)
    {
        if (!canAct)
        {
            Console.WriteLine($"{name} не може діяти цього ходу!");
            return;
        }

        int damage = PDMG;
        enemy.HP -= damage;
        Console.WriteLine($"{name} атакує {enemy.name} і завдає {damage} урону!");
    }
}

//=====В.4 Add Parameter після рефакторингу=====

using System;
using System.Collections.Generic;

class Player
{
    public string name;
    public int HP;
    public int PsP;
    public int EP;
    public int PDMG;
    public int MDMG;
    public int actionLevel;
    public List<Skill> skills;
    public bool isPanicking;
    public bool canAct;

    // Додано параметр bodyPart (Add Parameter)
    public void Attack(EnemyBoss enemy, string bodyPart)
    {
        if (!canAct)
        {
            Console.WriteLine($"{name} не може діяти цього ходу!");
            return;
        }

        if (enemy.bodyParts.ContainsKey(bodyPart))
        {
            int damage = PDMG;
            enemy.bodyParts[bodyPart].HP -= damage;
            Console.WriteLine($"{name} атакує {bodyPart} ворога {enemy.name} і завдає {damage} урону!");
        }
        else
        {
            Console.WriteLine($"{name} промахнувся! Частину тіла {bodyPart} не знайдено.");
        }
    }
}

//=====В.5 Pull up до рефакторингу=====
using System;
using System.Collections.Generic;

class EnemyBoss
{
    public string name;
    public int HP;
    public string bossType;
    public Dictionary<string, BodyPart> bodyParts;
    public string currentSin;

    public EnemyBoss(string name)
    {
        this.name = name;
        HP = 100;
        bodyParts = new Dictionary<string, BodyPart>()
        {
            { "head", new BodyPart("head", 40) },
            { "arm", new BodyPart("arm", 30) },
            { "leg", new BodyPart("leg", 30) }
        };
    }
}

class GreedBoss : EnemyBoss
{
    public GreedBoss(string name) : base(name) { }

    public void AttackPlayer(Player player)
    {
        int damage = 10;
        player.HP -= damage;
        Console.WriteLine($"{name} (Greed) атакує {player.name} і завдає {damage} урону!");
    }
}

class SlothBoss : EnemyBoss
{
    public SlothBoss(string name) : base(name) { }

    public void AttackPlayer(Player player)
    {
        int damage = 5;
        player.EP -= damage;
        Console.WriteLine($"{name} (Sloth) накладає Sloth на {player.name}, зменшуючи EP на {damage}!");
    }
}

class WrathBoss : EnemyBoss
{
    public WrathBoss(string name) : base(name) { }

    public void AttackPlayer(Player player)
    {
        int damage = 15;
        player.HP -= damage;
        Console.WriteLine($"{name} (Wrath) атакує {player.name} і завдає {damage} урону!");
    }
}

//=====В.6 Pull up після рефакторингу=====
using System;
using System.Collections.Generic;

class EnemyBoss
{
    public string name;
    public int HP;
    public string bossType;
    public Dictionary<string, BodyPart> bodyParts;
    public string currentSin;

    public EnemyBoss(string name)
    {
        this.name = name;
        HP = 100;
        bodyParts = new Dictionary<string, BodyPart>()
        {
            { "head", new BodyPart("head", 40) },
            { "arm", new BodyPart("arm", 30) },
            { "leg", new BodyPart("leg", 30) }
        };
    }

    // Метод винесено в базовий клас
    public virtual void AttackPlayer(Player player)
    {
        int damage = 10; // базова атака
        player.HP -= damage;
        Console.WriteLine($"{name} атакує {player.name} і завдає {damage} урону!");
    }
}

class GreedBoss : EnemyBoss
{
    public GreedBoss(string name) : base(name) { }
}

class SlothBoss : EnemyBoss
{
    public SlothBoss(string name) : base(name) { }

    public override void AttackPlayer(Player player)
    {
        int damage = 5;
        player.EP -= damage;
        Console.WriteLine($"{name} накладає Sloth на {player.name}, зменшуючи EP на {damage}!");
    }
}

class WrathBoss : EnemyBoss
{
    public WrathBoss(string name) : base(name) { }

    public override void AttackPlayer(Player player)
    {
        int damage = 15;
        player.HP -= damage;
        Console.WriteLine($"{name} атакує {player.name} і завдає {damage} урону!");
    }
}

