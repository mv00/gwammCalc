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

            character = new Character();
            _characterRepository = characterRepository;
            _characterRepository.Load();
            characterNames = _characterRepository.GetCharacterNames().ToList();

            characterNames.ForEach(name => characterCmb.Items.Add(name));
        }

        #region carto
        private void ProphCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            character.ProphCarto = prophCartoChk.Checked;
            ChildCheckBoxUpdated((CheckBox)sender, legendaryCartoChk, _cartoCheckBoxList);
        }

        private void CanthaCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryCartoChk, _cartoCheckBoxList);
        }

        private void NfCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryCartoChk, _cartoCheckBoxList);
        }

        private void LegendaryCartoChk_CheckedChanged(object sender, EventArgs e)
        {
            ParentCheckBoxUpdated((CheckBox)sender, _cartoCheckBoxList);
        }
        #endregion

        #region guardian
        private void ProphNMGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void ProphHMGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void CanthaNMGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList); ;
        }

        private void CanthaHMGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void NfNMGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryGuardianChk, _guardianCheckBoxList);
        }

        private void NfHMGuardianChk_CheckedChanged(object sender, EventArgs e)
        {
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
            ChildCheckBoxUpdated((CheckBox)sender, legendaryVanqChk, _vanqCheckBoxList);
        }

        private void CanthaVanqChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendaryVanqChk, _vanqCheckBoxList);
        }

        private void NfVanqChk_CheckedChanged(object sender, EventArgs e)
        {
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
            ChildCheckBoxUpdated((CheckBox)sender, legendarySkillHunterChk, _skillHunterCheckBoxList);
        }

        private void CanthaSkillHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            ChildCheckBoxUpdated((CheckBox)sender, legendarySkillHunterChk, _skillHunterCheckBoxList);
        }

        private void NfSkillHunterChk_CheckedChanged(object sender, EventArgs e)
        {
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
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void PartyChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void SurvivorChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void SweetToothChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        #region common
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
                children.ForEach(box => { box.Checked = false; box.Enabled = true; });
            }

            UpdateTitleCount(parent);
        }
        #endregion

        #region account-based
        private void LdoaChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void LbChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void SunspearChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void AsuraChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void NornChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void DelverChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void EbonVanquardChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void MasterOftheNorthChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        #region Account wide PvE
        private void LuckyChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void UnluckyChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void TreasureHunterChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void WisdomChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void ZaishenChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void KurzickChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void LuxonChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        #region Account wide PvP
        private void ChampionChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void CodexChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void GamerChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void GladiatorChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }

        private void HeroChk_CheckedChanged(object sender, EventArgs e)
        {
            OrphanCheckBoxUpdated((CheckBox)sender);
        }
        #endregion

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(characterCmb.Text))
            {
                MessageBox.Show("choose character name to save");
            }
            else if(string.IsNullOrWhiteSpace(character.CharacterName))
            {
                character.CharacterName = characterCmb.Text;
                _characterRepository.Add(character);
            }
            else
            {
                _characterRepository.Save();
            }
        }

        private void characterCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterName = characterCmb.Items[characterCmb.SelectedIndex].ToString();

            if (!string.IsNullOrWhiteSpace(characterName))
            {
                character = _characterRepository.GetCharacter(characterName);
                UpdateCheckboxes();
            }
        }

        private void UpdateCheckboxes()
        {
            prophCartoChk.Checked = character.ProphCarto;
        }
    }
}
