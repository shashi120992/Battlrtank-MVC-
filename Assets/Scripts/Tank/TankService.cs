using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Others;
using TankS;


namespace Tank
{
    public class TankService : GenericSingleton<TankService>
    {
        public TankSOList tankList;
        private TankModel currentTankModel;
        private TankController tankController;
        public int tankSpawnDelay = 3;

        public TankSO tankScriptable { get; private set; }
        private List<TankController> tanks = new List<TankController>();

        async private void Start()
        {

            await new WaitForSeconds(tankSpawnDelay);
            CreateTank(); 
        }
        public void CreateTank()
        {
            int rand = Random.Range(0, tankList.tanks.Length);
            tankScriptable = tankList.tanks[rand];

            TankModel tankModel = new TankModel(tankScriptable, tankList);
            currentTankModel = tankModel;
            tankController = new TankController(tankModel, tankScriptable.tankView);
            tanks.Add(tankController);
        }

        public TankModel GetCurrentTankModel()
        {
            return currentTankModel;
        }
        public TankController GetTankController(int index = 0)
        {
            return tanks[index];
        }

        public void DestroyTank(TankController tank)
        {
            tank.DestroyController();
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] == tank)
                {
                    tanks[i] = null;
                    tanks.Remove(tank);
                }
            }
        }
        public void TurnONTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] != null)
                {
                    tanks[i].tankView.gameObject.SetActive(true);

                }
            }
        }
        public void TurnOFFTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] != null)
                {
                    if (tanks[i].tankView)
                        tanks[i].tankView.gameObject.SetActive(false);
                }
            }
        }
    }
}