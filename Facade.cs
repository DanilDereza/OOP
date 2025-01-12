using System;

namespace Facade
{
    public class Amplifier
    {
        public void on()
        {
            Console.WriteLine("Amplifair is on");
        }
        public void off()
        {
            Console.WriteLine("Amplifair is off");
        }
        int volume;
        public void setVolume(int volume)
        {
            this.volume = volume;
            Console.WriteLine("Amplifair volume is " + volume);
        }
    }

    public class Tuner
    {
        private Amplifier amplifier;
        public Tuner(Amplifier amplifier)
        {
            this.amplifier = amplifier;
        }
        int fm, am, frequensy;
        public void setFm(int fm)
        {
            this.fm = fm;
        }
        public void setAm(int am)
        {
            this.am = am;
        }
        public void on()
        {
            Console.WriteLine("Tuner is on");
        }
        public void off()
        {
            Console.WriteLine("Tuner is off");
        }
        public void setFrequency(int fre)
        {
            this.frequensy = fre;
        }
    }

    public class DvdPlayer
    {
        private Amplifier amplifier;
        public DvdPlayer(Amplifier amplifier)
        {
            this.amplifier = amplifier;
        }
        public void on()
        {
            Console.WriteLine("DvdPlayer is on");
        }
        public void off()
        {
            Console.WriteLine("DvdPlayer is off");
        }
        public void play()
        {
            Console.WriteLine("DvdPlayer is playing");
        }
        public void pause()
        {
            Console.WriteLine("DvdPlayer is paused");
        }
        int number;
        public void setDvd(int numberofdvd)
        {
            this.number = numberofdvd;
        }
        public void eject()
        {
            Console.WriteLine("Dvd was ejected!");
        }
    }

    public class CdPlayer
    {
        private Amplifier amplifier;
        public CdPlayer(Amplifier amplifier)
        {
            this.amplifier = amplifier;
        }
        public void on()
        {
            Console.WriteLine("CdPlayer is on");
        }
        public void off()
        {
            Console.WriteLine("CdPlayer is off");
        }
        public void play()
        {
            Console.WriteLine("CdPlayer is playing");
        }
        public void pause()
        {
            Console.WriteLine("CdPlayer is paused");
        }
    }

    public class Projector
    {
        private DvdPlayer dvdplayer;
        public Projector(DvdPlayer dvd)
        {
            this.dvdplayer = dvd;
        }
        public void on()
        {
            Console.WriteLine("Projector is on");
        }
        public void off()
        {
            Console.WriteLine("Projector is off");
        }
    }

    public class PopcornPopper
    {
        public void on()
        {
            Console.WriteLine("PopcornPopper is on");
            pop();
        }
        public void off()
        {
            Console.WriteLine("PopcornPopper is off");
        }
        public void pop()
        {
            Console.WriteLine("PopcornPopper dropped popcorn!");
        }
    }

    class HomeTheaterFacade
    {
        Amplifier amplifier;
        Tuner tuner;
        DvdPlayer dvdplayer;
        CdPlayer cdplayer;
        Projector projector;
        PopcornPopper popcornpopper;

        public HomeTheaterFacade(Amplifier amplifier, Tuner tuner, DvdPlayer dvdplayer, CdPlayer cdplayer, Projector projector, PopcornPopper popcornpopper)
        {
            this.amplifier = amplifier;
            this.tuner = tuner;
            this.dvdplayer = dvdplayer;
            this.cdplayer = cdplayer;
            this.projector = projector;
            this.popcornpopper = popcornpopper;
        }
        public void watchMovie()
        {
            dvdplayer.on();
            cdplayer.on();
            amplifier.on();
            tuner.on();
            projector.on();
            popcornpopper.on();
        }
        public void endMovie()
        {
            dvdplayer.off();
            cdplayer.on();
            amplifier.off();
            tuner.off();
            projector.off();
            popcornpopper.off();
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Amplifier amplifier = new Amplifier();
            Tuner tuner = new Tuner(amplifier);
            DvdPlayer DvD = new DvdPlayer(amplifier);
            CdPlayer CD = new CdPlayer(amplifier);
            Projector projector = new Projector(DvD);
            PopcornPopper popcorn = new PopcornPopper();
            HomeTheaterFacade cinema = new HomeTheaterFacade(amplifier, tuner, DvD, CD, projector, popcorn);
            cinema.watchMovie();
            cinema.endMovie();
        }
    }
}
