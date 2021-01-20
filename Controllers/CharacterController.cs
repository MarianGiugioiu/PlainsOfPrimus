using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlainsOfPrimus.Models;
using Microsoft.AspNet.Identity;

namespace PlainsOfPrimus.Controllers
{
    public class CharacterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Character
        

        // GET: Character/Details/5
        public ActionResult Details()
        {
            
            var userId = User.Identity.GetUserId();
            var character = db.Characters
                .Include(b => b.Weapon)
                .Include(b => b.Helmet)
                .Include(b => b.Chestplate)
                .Include(b => b.Leggings)
                .Include(b => b.Boots)
                .Include(b => b.Achievements)
                .Where(b => b.UserId == userId).First();
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        public ActionResult DetailsAnother(int id)
        {

            var character = db.Characters
                .Include(b => b.Weapon)
                .Include(b => b.Helmet)
                .Include(b => b.Chestplate)
                .Include(b => b.Leggings)
                .Include(b => b.Boots)
                .Include(b => b.Achievements)
                .Where(b => b.Id == id).First();
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Character/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Class,Level")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(character);
        }

        [HttpGet]
        [Route("Character/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            var character = db.Characters
                .Include(b => b.Weapon)
                .Include(b => b.Helmet)
                .Include(b => b.Chestplate)
                .Include(b => b.Leggings)
                .Include(b => b.Boots)
                .Include(b => b.Achievements)
                .Where(b => b.UserId == userId).First();
            var characterViewModel = new CharacterViewModel();
            characterViewModel.Character = character;
            var achievementIds = new List<int>();
            foreach (Achievement achievement in character.Achievements)
            {
                achievementIds.Add(achievement.Id);
            }
            characterViewModel.AchievementIds = achievementIds.ToArray();
            characterViewModel.Weapons = GetAllWeapons();
            characterViewModel.Helmets = GetAllArmors("helmet");
            characterViewModel.Chestplates = GetAllArmors("chestplate");
            characterViewModel.Leggings = GetAllArmors("leggings");
            characterViewModel.Boots = GetAllArmors("boots");
            characterViewModel.Achievements = GetAllAchievements();
            int attackDamage = 0;
            int armorValue = 0;
            int health = 0;
            int intellect = 0;
            int strength = 0;
            int agility = 0;

            if (character.Weapon != null)
            {
                attackDamage = character.Weapon.AttackDamage;
                characterViewModel.WeaponId = character.Weapon.Id;
            }
            if (character.Helmet != null)
            {
                characterViewModel.HelmetId = character.Helmet.Id;
                armorValue += character.Helmet.ArmorValue;
                health += character.Helmet.Health;
                intellect += character.Helmet.Intellect;
                strength += character.Helmet.Strength;
                agility += character.Helmet.Agility;
            }
            if (character.Chestplate != null)
            {
                characterViewModel.ChestplateId = character.Chestplate.Id;
                armorValue += character.Chestplate.ArmorValue;
                health += character.Chestplate.Health;
                intellect += character.Chestplate.Intellect;
                strength += character.Chestplate.Strength;
                agility += character.Chestplate.Agility;
            }
            if (character.Leggings != null)
            {
                characterViewModel.LeggingsId = character.Leggings.Id;
                armorValue += character.Leggings.ArmorValue;
                health += character.Leggings.Health;
                intellect += character.Leggings.Intellect;
                strength += character.Leggings.Strength;
                agility += character.Leggings.Agility;
            }
            if (character.Boots != null)
            {
                characterViewModel.BootsId = character.Boots.Id;
                armorValue += character.Boots.ArmorValue;
                health += character.Boots.Health;
                intellect += character.Boots.Intellect;
                strength += character.Boots.Strength;
                agility += character.Boots.Agility;
            }

            characterViewModel.AttackDamage = attackDamage;
            characterViewModel.ArmorValue = armorValue;
            characterViewModel.Health = health;
            characterViewModel.Intellect = intellect;
            characterViewModel.Strength = strength;
            characterViewModel.Agility = agility;

            if (character == null)
            {
                return HttpNotFound();
            }
            return View(characterViewModel);
        }

        [HttpPut]
        [Route("Character/Edit/{id}")]
        public ActionResult Edit(int id, CharacterViewModel characterViewModel)
        {

            var userId = User.Identity.GetUserId();
            var character = db.Characters.Include(b => b.Achievements).Where(b => b.UserId == userId).First();
            characterViewModel.Weapons = GetAllWeapons();
            characterViewModel.Helmets = GetAllArmors("helmet");
            characterViewModel.Chestplates = GetAllArmors("chestplate");
            characterViewModel.Leggings = GetAllArmors("leggings");
            characterViewModel.Boots = GetAllArmors("boots");
            characterViewModel.Achievements = GetAllAchievements();
            var weapon = db.Weapons.Find(characterViewModel.WeaponId);
            var helmet = db.Armors.Find(characterViewModel.HelmetId);
            var chestplate = db.Armors.Find(characterViewModel.ChestplateId);
            var leggings = db.Armors.Find(characterViewModel.LeggingsId);
            var boots = db.Armors.Find(characterViewModel.BootsId);
            var achievements = new List<Achievement>();
            if (characterViewModel.AchievementIds != null)
            {
                foreach (int achievementId in characterViewModel.AchievementIds)
                {

                    var achievement = db.Achievements.Find(achievementId);
                    achievements.Add(achievement);


                }
            }
            
            if (ModelState.IsValid)
            {
                character.Name = characterViewModel.Character.Name;
                character.Level = characterViewModel.Character.Level;
                character.Class = characterViewModel.Character.Class;
                character.Weapon = weapon;
                character.Helmet = helmet;
                character.Chestplate = chestplate;
                character.Leggings = leggings;
                character.Boots = boots;
                character.Achievements = achievements;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(characterViewModel);
        }

        
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        

        public IEnumerable<SelectListItem> GetAllWeapons()
        {
            var selectList = new List<SelectListItem>();

            foreach (var weapon in db.Weapons.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = weapon.Id.ToString(),
                    Text = weapon.Name
                });
            }
            return selectList;
        }
        public IEnumerable<SelectListItem> GetAllArmors(string typeString)
        {
            var selectList = new List<SelectListItem>();

            foreach (var armor in db.Armors.Where(b => b.Type.Equals(typeString)).ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = armor.Id.ToString(),
                    Text = armor.Name
                });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetAllAchievements()
        {
            var selectList = new List<SelectListItem>();

            foreach (var achievement in db.Achievements.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = achievement.Id.ToString(),
                    Text = achievement.Name
                });
            }
            return selectList;
        }
    }
}
