using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class TestProtobuf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //User user = new User();
        //user.ID = 100;
        //user.Username = "siki";
        //user.Password = "123456";
        //user.Level = 100;
        //user._UserType = User.UserType.Master;

        //FileStream fs = File.Create(Application.dataPath + "/user.bin");
        //Serializer.Serialize(fs, user);
        //fs.Close();

        //using(FileStream fs = File.Create(Application.dataPath + "/user.bin"))
        //{
        //    Serializer.Serialize(fs, user);
        //}

        User user = null;
        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user = Serializer.Deserialize<User>(fs);
        }

        print(user.ID);
        print(user.Username);
        print(user.Password);
        print(user.Level);
        print(user._UserType);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
