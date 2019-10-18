using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GwammCalc
{
    public partial class mainForm : Form
    {
        private List<CheckBox> _guardianCheckBoxList;
        private List<CheckBox> _cartoCheckBoxList;
        private List<CheckBox> _vanqCheckBoxList;
        private List<CheckBox> _skillHunterCheckBoxList;
        private readonly ICharacterRepository _characterRepository;

        private Character character;
        private List<string> characterNames;

        public mainForm(ICharacterRepository characterRepository)
        {
            InitializeComponent();

            _characterRepository = characterRepository;

            characterCmb.Text = "<character name>";
            LoadChildCheckBoxLists();
            LoadCharacterData();
        }

        private void UpdateCheckboxes()
        {
            prophCartoChk.Checked = character.ProphCarto;
            canthaCartoChk.Checked = character.CanthaCarto;
            nfCartoChk.Checked = character.NfCarto;

            prophProtectorChk.Checked = character.ProphProtector;
            prophGuardianChk.Checked = character.ProphGuardian;
            canthaProtectorChk.Checked = character.CanthaProtector;
            canthaGuardianChk.Checked = character.CanthaGuardian;
            nfProtectorChk.Checked = character.NfProtector;
            nfGuardianChk.Checked = character.NfGuardian;

            prophVanqChk.Checked = character.ProphVanq;
            canthaVanqChk.Checked = character.CanthaVanq;
            nfVanqChk.Checked = character.NfVanq;

            prophSkillHunterChk.Checked = character.ProphSkillHunter;
            canthaSkillHunterChk.Checked = character.CanthaSkillHunter;
            nfSkillHunterChk.Checked = character.NfSkillHunter;

            drunkardChk.Checked = character.Drunkard;
            partyChk.Checked = character.Party;
            sweetToothChk.Checked = character.SweetTooth;
            survivorChk.Checked = character.Survivor;

            ldoaChk.Checked = character.Ldoa;
            lbChk.Checked = character.Lightbringer;
            sunspearChk.Checked = character.Sunspear;
            asuraChk.Checked = character.Asura;
            nornChk.Checked = character.Norn;
            delverChk.Checked = character.Delver;
            ebonVanquardChk.Checked = character.EbonVanquard;
            masterOftheNorthChk.Checked = character.MasterOftheNorth;

            luckyChk.Checked = character.Lucky;
            unluckyChk.Checked = character.Unlucky;
            treasureHunterChk.Checked = character.TreasureHunter;
            wisdomChk.Checked = character.Wisdom;
            zaishenChk.Checked = character.Zaishen;
            kurzickChk.Checked = character.Kurzick;
            luxonChk.Checked = character.Luxon;

            championChk.Checked = character.Champion;
            codexChk.Checked = character.Codex;
            gamerChk.Checked = character.Gamer;
            gladiatorChk.Checked = character.Gladiator;
            heroChk.Checked = character.Hero;
        }

        private void LoadCharacterData()
        {
            character = new Character();
            _characterRepository.Load();
            characterNames = _characterRepository.GetCharacterNames().ToList();

            characterNames.ForEach(name => characterCmb.Items.Add(name));
        }

        private void LoadChildCheckBoxLists()
        {
            _guardianCheckBoxList = new List<CheckBox>
            {
                prophProtectorChk,
                canthaProtectorChk,
                nfProtectorChk,
                prophGuardianChk,
                canthaGuardianChk,
                nfGuardianChk
            };

            _cartoCheckBoxList = new List<CheckBox>
            {
                prophCartoChk,
                canthaCartoChk,
                nfCartoChk
            };

            _vanqCheckBoxList = new List<CheckBox>
            {
                prophVanqChk,
                canthaVanqChk,
                nfVanqChk
            };

            _skillHunterCheckBoxList = new List<CheckBox>
            {
                prophSkillHunterChk,
                canthaSkillHunterChk,
                nfSkillHunterChk
            };
        }

        private void Reset()
        {
            character = new Character();
            characterCmb.Items.Clear();
            characterCmb.Text = "<character name>";

            UpdateCheckboxes();
            LoadCharacterData();
        }

        #region carto
        private void ProphCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            character.ProphCarto = prophCartoChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryCartoChk, _cartoCheckBoxList);
        }

        private void CanthaCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            character.CanthaCarto = canthaCartoChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryCartoChk, _cartoCheckBoxList);
        }

        private void NfCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            character.NfCarto = nfCartoChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryCartoChk, _cartoCheckBoxList);
        }

        private void LegendaryCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            ParentCheckBoxUpdated((CheckBox)sender, _cartoCheckBoxList);
        }
        #endregion

        #region guardian
        private void ProphProtectorChk_CheckedChanged(object sender, EventArgs e)
        {
            character.ProphProtector = prophProtectorChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void ProphGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            character.ProphGuardian = prophGuardianChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void CanthaProtectorChk_CheckedChanged(object sender, EventArgs e)
        {
            character.CanthaProtector = canthaProtectorChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList); ;
        }

        private void CanthaGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            character.CanthaGuardian = canthaGuardianChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void NfProtectorChk_CheckedChanged(object sender, EventArgs e)
        {
            character.NfProtector = nfProtectorChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void NfGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            character.NfGuardian = nfGuardianChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void LegendaryGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            ParentCheckBoxUpdated((CheckBox)sender, _guardianCheckBoxList);
        }
        #endregion

        #region vanq
        private void ProphVanqChk_CheckedChanged(object sender, EventArgs e)
        {
            character.ProphVanq = prophVanqChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryVanqChk, _vanqCheckBoxList);
        }

        private void CanthaVanqChk_CheckedChanged(object sender, EventArgs e)
        {
            character.CanthaVanq = canthaVanqChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryVanqChk, _vanqCheckBoxList);
        }

        private void NfVanqChk_CheckedChanged(object sender, EventArgs e)
        {
            character.NfVanq = nfVanqChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryVanqChk, _vanqCheckBoxList);
        }

        private void LegendaryVanqChk_CheckedChanged(object sender, EventArgs e)
        {
            ParentCheckBoxUpdated((CheckBox)sender, _vanqCheckBoxList);
        }
        #endregion

        #region skillhunter
        private void ProphSkillHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            character.ProphSkillHunter = prophSkillHunterChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendarySkillHunterChk, _skillHunterCheckBoxList);
        }

        private void CanthaSkillHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            character.CanthaSkillHunter = canthaSkillHunterChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendarySkillHunterChk, _skillHunterCheckBoxList);
        }

        private void NfSkillHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            character.NfSkillHunter = nfSkillHunterChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendarySkillHunterChk, _skillHunterCheckBoxList);
        }

        private void LegendarySkillHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            ParentCheckBoxUpdated((CheckBox)sender, _skillHunterCheckBoxList);
        }
        #endregion

        #region core
        private void DrunkardChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Drunkard = drunkardChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void PartyChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Party = partyChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void SurvivorChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Survivor = survivorChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void SweetToothChk_CheckedChanged(object sender, EventArgs e)
        {
            character.SweetTooth = sweetToothChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        #region other

        private void LdoaChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Ldoa = ldoaChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void LbChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Lightbringer = lbChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void SunspearChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Sunspear = sunspearChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void AsuraChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Asura = asuraChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void NornChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Norn = nornChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void DelverChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Delver = delverChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void EbonVanquardChk_CheckedChanged(object sender, EventArgs e)
        {
            character.EbonVanquard = ebonVanquardChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void MasterOftheNorthChk_CheckedChanged(object sender, EventArgs e)
        {
            character.MasterOftheNorth = masterOftheNorthChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        #region Account wide PvE
        private void LuckyChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Lucky = luckyChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void UnluckyChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Unlucky = unluckyChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void TreasureHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            character.TreasureHunter = treasureHunterChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void WisdomChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Wisdom = wisdomChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void ZaishenChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Zaishen = zaishenChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void KurzickChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Kurzick = kurzickChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void LuxonChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Luxon = luxonChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        #region Account wide PvP
        private void ChampionChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Champion = championChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void CodexChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Codex = codexChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void GamerChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Gamer = gamerChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void GladiatorChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Gladiator = gladiatorChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void HeroChk_CheckedChanged(object sender, EventArgs e)
        {
            character.Hero = heroChk.Checked;
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion


        private void UpdateTitleCount(CheckBox checkBox)
        {
            if (checkBox.Checked)
                TitleCounter.AddTitle();
            else
                TitleCounter.RemoveTitle();

            titleCountNumber.Text = TitleCounter.CurrentTitleCount.ToString();

            if (TitleCounter.CurrentTitleCount >= 30)
            {
                gwammLbl.Visible = true;
                gwammLbl.Refresh();
            }

            else
                gwammLbl.Visible = false;
        }

        private void OrphanCheckBoxUpdated(CheckBox orphan)
        {
            UpdateTitleCount(orphan);
        }

        private void ChildCheckBoxUpdated(CheckBox child, CheckBox parent, List<CheckBox> children)
        {
            UpdateTitleCount(child);

            if (children.TrueForAll(box => box.Checked))
                parent.Checked = true;
            else
                parent.Checked = false;
        }

        private void ParentCheckBoxUpdated(CheckBox parent, List<CheckBox> children)
        {
            if (parent.Checked && children.TrueForAll(box => box.Checked))
            {
                children.ForEach(box => box.Enabled = false);
            }
            else if (parent.Checked)
            {
                children.ForEach(box => { box.Checked = true; box.Enabled = false; });
            }
            else
            {
                children.ForEach(box => { box.Enabled = true; });
            }

            UpdateTitleCount(parent);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(characterCmb.Text) || characterCmb.Text.Equals("<character name>"))
            {
                MessageBox.Show("choose character name to save");
            }
            else if (string.IsNullOrWhiteSpace(character.CharacterName))
            {
                character.CharacterName = characterCmb.Text;
                _characterRepository.Add(character);
            }
            else
            {
                _characterRepository.Save();
            }
        }

        private void CharacterCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterName = characterCmb.Items[characterCmb.SelectedIndex].ToString();

            if (!string.IsNullOrWhiteSpace(characterName))
            {
                character = _characterRepository.GetCharacter(characterName);
                UpdateCheckboxes();
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            _characterRepository.Remove(character);
            Reset();
        }
    }
}
