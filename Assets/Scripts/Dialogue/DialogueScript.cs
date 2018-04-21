using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {
    //private List<List<string>> dialogues = new List<List<string>>();
    // Use this for initialization
    Dictionary<string, List<string>> dialogues = new Dictionary<string, List<string>>();
    private void Awake() {
        setHealthEmail();
        setDeanEmail();
        setMomText();
        setHopeDialogue();
        setBriDialogue();

    }

    public Dictionary<string, List<string>> getDialogues() {
        return dialogues;
    }

    private void setHealthEmail() {
        List<string> currDia = new List<string>();
        currDia.Add("You received an email");
        currDia.Add("It's from Health Services");
        dialogues.Add("health", currDia);
    }

    //index 1
    private void setDeanEmail() {
        List<string> currDia = new List<string>();
        currDia.Add("You received an email");
        currDia.Add("it's from Dean White");
        dialogues.Add("dean", currDia);
    }

    private void setMomText() {
        List<string> currDia = new List<string>();
        currDia.Add("Mom: Chi, have you heard from Brianna?");
        currDia.Add("Mom: Your sister has really outdone herself this time! She hasn’t come home and won’t return any of my messages.");
        currDia.Add("Mom: Your father just about lost it when she gave us the news. What will people say about her now?");
        currDia.Add("Mom: I would call, but I’m working double shifts for the entire week, and I need you to make sure she’s safe.");
        currDia.Add("Mom: She left a receipt of a bus ticket on the printer at home, heading towards your campus.");
        currDia.Add("Mom: Make sure she’s alright and talk some sense into her! You’ve always been the more responsible one.");
        currDia.Add("Mom: She needs to be realistic about her life now that she will have more responsibilities! ");
        currDia.Add("Mom: Anyway, keep working hard at your studies and make us proud. We need you back home now more than ever.");
        currDia.Add("Mom: Your father and I love you very much.");
        dialogues.Add("mom", currDia);
    }
    private void setHopeDialogue() {
        List<string> currDia = new List<string>();
        currDia.Add("Hope: Hey Chi!.. Wait up!");
        currDia.Add("Hope: How’ve you been!? I haven’t seen you since you moved into a single at the end of sophomore year.");
        currDia.Add("Hope: Come to think of it..we never really kept in touch! Don’t tell me you hate me now!");
        currDia.Add("Chi: What? No! I’ve just been really busy with work and school. I’m taking like 22 credits this semester and I’m swamped with work.");
        currDia.Add("Hope: Damn, that’s intense. I saw that you had your head down, so I was wondering what's up.");
        currDia.Add("Hope: You tend to do that when you have a lot on your mind.");
        currDia.Add("Hope: I miss you though. Remember when we used to challenge each other in Karlos Kart on my Cube?");
        currDia.Add("Hope: You'd always be so competitive, and it was hilarious when you just LOST!");
        currDia.Add("Hope: Just remember not to take this whole school thing too seriously and have some fun along the way.");
        currDia.Add("Hope: Plus, you know you're a smarty pants and a hard worker. People would kill to have passion and drive like you!");
        currDia.Add("Chi: Haha thanks. It's just really hard sometimes to stop and breathe for a second. I feel so behind all the time.");
        currDia.Add("Chi: And it's hard talking about these things you know? Everyone here is so damn put together. Even you! How do you do it?");
        currDia.Add("Hope: It's called faking it! Dude, just look around you. Everyone here suffers from perfectionism.");
        currDia.Add("Hope: The environment here can be really toxic,");
        currDia.Add("Hope: and I guess it's because of being at a \"high and mighty prestigious institution.\" ");
        currDia.Add("Hope: And we both know that I didn't know what the hell I was doing my first year here.");
        currDia.Add("Hope: They don't teach First Gens like us how to navigate this shit at all. But hey, they didn't create integration programs like Inclusivity for nothing.");
        currDia.Add("Hope: I feel like the support group I got from Inclusivity definitely helped me get my act together, and that's the one thing Ivy did right.");
        currDia.Add("Hope: We're all struggling together, you know?");
        currDia.Add("Hope: Hey, why don't you come to one of our meetings?");
        currDia.Add("Hope: I know your family wouldn't let you leave for campus early enough to join the program,");
        currDia.Add("Hope: but you'd be more than welcome to hang out with us. Plus..we can finally have that Karlos Kart rematch!");
        currDia.Add("Chi: Thanks..I'll think about it, but I have a lot on my plate right now.");
        currDia.Add("Chi: Damn, I gotta run now. I have a ton of shit to do that I've been dodging. I'll see you around");
        currDia.Add("Hope: ...alright, but I think you're being too hard on yourself.");
        currDia.Add("Hope: Just know that you can be your own worst enemy.");
        currDia.Add("And if you ever want to talk about stuff...then I'm here for you.");
        dialogues.Add("hope", currDia);
    }

    private void setBriDialogue() {
        List<string> c = new List<string>();
        c.Add("Bri: Hey Chi-Chi! Show some love to your baby sis who travelled mad hours to come and visit you!");
        c.Add("Bri: I'd smother you with hugs and kisses right now, but I may puke from that bus ride.");
        c.Add("Bri: My stomach hasn't been right since this kiddo's been in my belly!");
        c.Add("Chi: Bri...Mom didn't tell me you're--");
        c.Add("Bri: Pregnant?");
        c.Add("Bri: I know seeing me like this may be a shock, and I also know your judgemental ass is looking down on me,");
        c.Add("Bri: but I promise having this baby won't change my dreams of becoming an actress.");
        c.Add("Chi: Seriously Bri? After everything Mom and Dad have done for us?");
        c.Add("Chi: They worked so hard to make sure that we didn't become a fucking label, a stereotype!");
        c.Add("Chi: You're basically a walking statistic.");
        c.Add("Bri: Calm down, Chi! You make it sound like I just fucked up my entire life!");
        c.Add("Bri: Mom thinks I have to become a fucking nun to have this baby, but I want to prove I can manage motherhood and still pursue a career!");
        c.Add("Bri: I wish Mom could see that things aren't as hard as it was in the old days.");
        c.Add("Bri: There's things like daycare, and I have plenty of friends who can babysit! You included when you graduate!");
        c.Add("Bri: And once the baby can walk, I can enroll in the daycare program at Sonia Sotomayor Community College.");
        c.Add("Chi: And what about the baby's dad? Mom won't stop texting me about all the rent and bills already.");
        c.Add("Chi: You know I have a lot on my plate, Bri.");
        c.Add("Chi: After all the begging I did to convince Mom and Dad to send me to Ivy College, I can't afford to let them down now.");
        c.Add("Chi: I had to leave our family behind to pursue this education, Bri. And you know how hard it was on them AND you.");
        c.Add("Bri: It's not like I'm gonna freeload and have you guys pay the cost of my baby!");
        c.Add("Bri: I know you don't think highly of me for my decisions to have this baby without a dad,");
        c.Add("Bri: But I'm gonna be his mommy AND daddy!");
        c.Add("Bri: Didn't you like, learn about this sort of stuff in all those feminist classes you've taken?");
        c.Add("Bri: Only the most badass women wouldn't let motherhood keep them from their dreams!");
        c.Add("Bri: ...Mom may have given up on me...but don't you give up on me too!");
        c.Add("Bri: You're the only person in the world I'd hope would support me.");
        c.Add("Chi: *Sigh* Of course I'll support you..Maybe I just wish I could feel as carefree as you.");
        c.Add("Chi: I'd be in fetal position if I found out I was pregnant!");
        c.Add("Chi: No matter what obstacles come your way, you've always been able to handle them in stride. Nothing can dampen your spirit.");
        c.Add("Chi: Meanwhile I crumble at the thought of a bad grade, or an internship I wasn't good enough for..");
        c.Add("Chi: It feels like I've just been dodging obstacles and running away from my problems whenever it feels like I might fail at something");
        c.Add("Bri: No kidding...but I also want you to know that I've always looked up to you since we were little.");
        c.Add("Bri: Yeah, you may be a bit too logical and sciency for my taste, but you never let anyone stop you from reaching the top.");
        c.Add("Bri: It's something kids like us wouldn't have dared to dream.");
        c.Add("Bri: Even at your lowest points, striving for perfection reminds me of how highly you see and want to see of yourself.");
        c.Add("Bri: I want to apply the same motto to myself,");
        c.Add("Bri: where even at the most difficult moments, no one can take away the love I feel for myself and this new life that will be born into this world.");
        c.Add("Bri: I can only show what IS possible even when it seems like the world is closing in on them.");
        c.Add("Chi: It never feels great to get preached by your baby sis, but...you're right..");
        c.Add("Chi:...thanks Bri.");
        c.Add("Chi: Now, let's go back to my room and call mom before she drives me insane! You need to talk to her. Don't worry, I got your back.");
        c.Add("Bri: Thanks Chi. You're the best sibling ever <3");
        dialogues.Add("bri", c);
    }
}//end of DialogueScript
