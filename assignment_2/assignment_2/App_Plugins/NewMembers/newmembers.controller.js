angular.module('umbraco').controller('CustomNewMembersController', function ($scope, entityResource, memberResource) {
    var vm = this;
    vm.sortedMembers = [];

    var members = [];

    entityResource.getAll("member")
        .then(function (basicMembersInfo) {

            console.log('its here!', basicMembersInfo);
            basicMembersInfo.forEach(basicMemberInfo => {

                memberResource.getByKey(basicMemberInfo.key)
                    .then(function (member) {
                        members.push(member);
                        console.log("add member");
                    }).then(function () {


                    var sorted = members.sort((a, b) => Date.parse(b.createDate) - Date.parse(a.createDate));

                    vm.sortedMembers = sorted;
                });

            })


        })



});