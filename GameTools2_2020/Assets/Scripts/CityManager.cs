using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRIDCITY
{
    public enum blockType { Block, Arches, Columns, Dishpivot, DomeWithBase, HalfDome, SlitDome, Slope, Tile};

    public class CityManager : MonoBehaviour
    {

        #region Fields
        private static CityManager _instance;
        public int size = 16;
        public Mesh[] meshArray;
        public Material[] materialArray;
        public Transform buildingPrefab;
        public BuildingProfile[] profileArray;
        public static bool[,,] occupiedBuilding;

        public static CityManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        #region Properties	
        #endregion

        #region Methods
        #region Unity Methods

        // Use this for internal initialization
        void Awake () {
            occupiedBuilding = new bool[size, size, size];
            if (_instance == null)
            {
                _instance = this;
            }

            else
            {
                Destroy(gameObject);
                Debug.LogError("Multiple CityManager instances in Scene. Destroying clone!");
            };
        }
		
		// Use this for external initialization
		void Start () {
			for (int i = 0; i < size; i++)
            {
                int k = Random.Range(0, size);
                int j = Random.Range(0, size);
                BuildingLocations(k,0,j);
                /*int random = Random.Range(0, profileArray.Length);
                Instantiate(buildingPrefab, new Vector3(i, 0.0f, j), Quaternion.identity).GetComponent<DeluxeTowerBlock>().SetProfile(profileArray[random]);*/
            }
		}
		
		// Update is called once per frame
		void Update () {
			
		}

        void BuildingLocations(int positionX, int positionY, int positionZ)
        {
            if (!occupiedBuilding[positionX,positionY,positionZ])
            {
                int random = Random.Range(0, profileArray.Length);
                Transform obj = Instantiate(buildingPrefab, new Vector3(positionX - size/2, positionY, positionZ - size / 2), Quaternion.identity);
                obj.GetComponent<DeluxeTowerBlock>().SetProfile(profileArray[random]);
                obj.GetComponent<DeluxeTowerBlock>().pos = new Vector3(positionX, positionY, positionZ);
                occupiedBuilding[positionX, positionY, positionZ] = true;
            }
        }

		#endregion
	#endregion
		
	}
}
