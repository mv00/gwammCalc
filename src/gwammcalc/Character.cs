namespace GwammCalc
{
    public class Character
    {
        public string CharacterName { get; set; }
       
        public bool ProphCarto { get; set; }
        public bool CanthaCarto { get; set; }
        public bool NfCarto { get; set; }

        public bool ProphProtector { get; set; }
        public bool CanthaProtector { get; set; }
        public bool NfProtector { get; set; }
        public bool NfGuardian { get; set; }
        public bool CanthaGuardian { get; set; }
        public bool ProphGuardian { get; set; }
                
        public bool NfVanq { get; set; }
        public bool CanthaVanq { get; set; }
        public bool ProphVanq { get; set; }

        
        public bool NfSkillHunter { get; set; }
        public bool CanthaSkillHunter { get; set; }
        public bool ProphSkillHunter { get; set; }

        public bool Survivor { get; set; }
        public bool Ldoa { get; set; }

        public bool Party { get; set; }
        public bool Drunkard { get; set; }
        public bool SweetTooth { get; set; }

        public bool Lightbringer { get; set; }
        public bool Sunspear { get; set; }
        public bool Delver { get; set; }
        public bool Asura { get; set; }
        public bool Norn { get; set; }
        public bool EbonVanquard { get; set; }
        public bool MasterOftheNorth { get; set; }

        public bool Hero { get; set; }
        public bool Codex { get; set; }
        public bool Gladiator { get; set; }
        public bool Gamer { get; set; }
        public bool Champion { get; set; }
        public bool Kurzick { get; set; }
        public bool Zaishen { get; set; }
        public bool Unlucky { get; set; }
        public bool Wisdom { get; set; }
        public bool TreasureHunter { get; set; }
        public bool Lucky { get; set; }
        public bool Luxon { get; set; }

        public bool LegendaryGuardian => ProphProtector &&
            CanthaProtector &&
            NfProtector &&
            ProphGuardian &&
            CanthaGuardian &&
            NfGuardian;

        public bool LegendaryCarto => ProphCarto && CanthaCarto && NfCarto;

        public bool LegendaryVanq => ProphVanq && CanthaVanq && NfVanq;

        public bool LegendarySkillHunter => ProphSkillHunter && CanthaSkillHunter && NfSkillHunter;
    }
}