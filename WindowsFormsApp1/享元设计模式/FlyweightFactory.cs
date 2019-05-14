using System;
using System.Collections.Generic;
using System.Text;

namespace 享元设计模式
{
    public static class FlyweightFactory
    {
        /// <summary>
        /// 缓存英雄信息
        /// </summary>
        public static Dictionary<personEnum, personBase> _personDictionary = new Dictionary<personEnum, personBase>();
        private static object obj = new object();
        /// <summary>
        /// 简单工厂用于构建选择了那几个英雄
        /// </summary>
        /// <param name="type">英雄类型枚举</param>
        /// <returns>具体英雄</returns>
        public static personBase BuildPersion(personEnum type)
        {
            ///判断是否存在，如果存在直接返会
            if (_personDictionary.ContainsKey(type))
            {
                return _personDictionary[type];
            }
            else //否则去构建 双if加lock形式
            {
                lock (obj)
                {
                    //如果存在直接从缓存中读取
                    if (_personDictionary.ContainsKey(type))
                    {
                        return _personDictionary[type];
                    }
                    else //否则构建
                    {
                        personBase personBase = new personBase();
                        switch (type)
                        {
                            case personEnum.liulang:
                                personBase = new liulang();
                                break;
                            case personEnum.pis:
                                personBase = new pis();
                                break;
                            case personEnum.xuemo:
                                personBase = new xuemo();
                                break;
                            case personEnum.smallBlack:
                                personBase = new smallBlack();
                                break;
                        }
                        _personDictionary.Add(type, personBase);
                        return personBase;
                    }
                }
            }
        }
    }


    public enum personEnum
    {
        liulang = 0,
        pis = 1,
        xuemo = 2,
        smallBlack = 3

    }
}
