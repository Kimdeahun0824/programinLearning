﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsInterface
{
    internal class Collection
    {
        public void CollectionDesc()
        {
            /**
             * 컬렉션 사용하기
             * 배열처럼 특정 항목의 집합을 리스트 또는 컬렉션이라고 한다.
             * 컬렉션은 배열, 리스트, 사전을 사용하여 관련 객체의 그룹을 만들고 관리한다.
             * 
             * 배열과 컬렉션
             * C#에서 배열(Array)과 컬렉션(Collection), 리스트(List)는 학습 레벨에서 동일하게 취급한다.
             * 컬렉션 클래스는 데이터 항목의 집합을 메모리상에서 다루는 클래스로, 문자열 같은 간단한 형태도 있다.
             * 그리고 특정 클래스 형식의 집합 같은 복잡한 형태도 있다. 
             * 
             * 3가지의 자주 쓰는 컬렉션 소개
             *  - 배열 : 일반적으로 숫자처럼 간단한 데이터 형식을 저장한다.
             *  - 리스트 : 간단한 데이터 형식을 포함한 객체들을 저장한다.
             *  - 사전(Dictionary) : 키와 값의 쌍으로 관리되는 객체들을 저장한다.
             *  
             * 일반적으로 기본형 그룹을 배열로 보고, 새로운 타입(클래스)의 그룹을
             * 컬렉션으로 비교하기도 한다.
             *  
             *  - 배열 : 정수형, 문자열 등 집합을 나타낸다.
             *  - 컬렉션 : 객체의 집합을 나타낸다. 리스트, 집합(set), 맵, 사전도 컬렉션과 같은 개념으로 사용한다.
             * 
             * 데이터를 그룹으로 묶어 관리할 때는 일반적으로 배열로 관리한다.
             * 배열은 크기가 고정되어 있다. 배열은 크기가 고정되어 있어 새로운 데이터를 추가할 수 없다. 
             * 이러한 단점을 제거한 것이 바로 컬렉션이다.
             * 
             *  - 컬렉션은 반복하여 사용할 수 있는 형식 안정성으로 크기를 동적으로 변경할 수 있는 장점이 있다.
             *  - 컬렉션은 데이터를 조회, 정렬, 중복 제거, 이름과 값을 쌍으로 관리하는 등 여러 장점이 있다.
             * 
             * 닷넷에서는 컬렉션과 관련한 여러 클래스를 제공한다.
             *  - Stack 클래스
             *  - Queue 클래스
             *  - ArrayList 클래스
             * 등이 있다.
             */
            
            Dictionary<string, int> inventory = new Dictionary<string, int>();

            inventory.Add("빨간 포션",10);
            inventory.Add("강철 검", 1);
            Console.WriteLine(inventory["빨간 포션"]);

            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(3);
            intList.Add(100);
            intList.Add(77);

            intList.Sort();
            intList.Reverse();

            foreach(int number in intList)
            {
                Console.WriteLine(number);
            }
        }       // CollectionDesc()
        struct Node
        {
            int _index;
            int number;
            int adressNext;
            int adressPrev;
        }
    }       // class Collection
}
